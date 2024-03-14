using System;
using Code.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Controllers
{
    public class CubeEaterController : MonoBehaviour, IPlaceableObject
    {
        [SerializeField] private Collider collider;
        [SerializeField] private Rigidbody rigidbody;
        [SerializeField] private float movementSpeed;
        [SerializeField] private float rotationSpeed;
        [Inject] IEdiblesHolder ediblesHolder;
        
        private CubeEaterMovementController movementController;
        private Vector3 targetPosition;
        private bool isMoving;
        private const float EATER_Y_POSITION_THRESHOLD = 0.05f;
        private float eaterYPosition;
        
        public void Place()
        {
            collider.isTrigger = true;
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            movementController = new CubeEaterMovementController(transform, movementSpeed, rotationSpeed, transform.position.y);
            ediblesHolder.OnEdibleAdded += OnEdiblesChanged;
            ediblesHolder.OnEdibleRemoved += OnEdiblesChanged;
            OnEdiblesChanged();
        }

        public void CancelPlacement()
        {
            Destroy(gameObject);
        }

        private void Update()
        {
            if (movementController == null || !isMoving) return;
            CalculateTargetPosition();
            if (transform.position.y - targetPosition.y > EATER_Y_POSITION_THRESHOLD) return;
            var direction = targetPosition - transform.position;
            movementController.Move(direction.normalized, Time.deltaTime);
            movementController.RotateTowards(targetPosition, Time.deltaTime);
        }

        private void OnTriggerEnter(Collider other)
        {
            HandleEdibleCollision(other);
        }

        private void OnTriggerStay(Collider other)
        {
            HandleEdibleCollision(other);
        }

        private void HandleEdibleCollision(Collider other)
        {
            if(other == null) return;
            IEdible edible = other.GetComponent<IEdible>();
            if (edible == null || !edible.Initialized) return;
            edible.GetEaten();
        }

        private void OnEdiblesChanged()
        {
            isMoving = ediblesHolder.Edibles.Count > 0;
            if (isMoving) return;
            
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }
        
        private void CalculateTargetPosition()
        {
            if (ediblesHolder.Edibles.Count == 0) return;
            var closestDistance = float.MaxValue;
            var closestEdible = ediblesHolder.Edibles[0];
            foreach (var edible in ediblesHolder.Edibles)
            {
                var distance = Vector3.Distance(transform.position, edible.Position);
                if (!(distance < closestDistance)) continue;
                closestDistance = distance;
                closestEdible = edible;
            }
            targetPosition = closestEdible.Position;
        }
    }
}
