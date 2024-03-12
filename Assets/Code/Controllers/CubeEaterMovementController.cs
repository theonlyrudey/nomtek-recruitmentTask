using UnityEngine;

namespace Code.Controllers
{
    public class CubeEaterMovementController
    {
        private readonly Transform eaterTransform;
        private readonly float movementSpeed;
        private readonly float rotationSpeed;
        
        public CubeEaterMovementController(Transform eaterTransform, float movementSpeed, float rotationSpeed)
        {
            this.eaterTransform = eaterTransform;
            this.movementSpeed = movementSpeed;
            this.rotationSpeed = rotationSpeed;
        }
        
        public void Move(Vector3 direction, float deltaTime)
        {
            eaterTransform.position += direction * (movementSpeed * deltaTime);
        }
        
        public void RotateTowards(Vector3 position, float deltaTime)
        {
            var direction = position - eaterTransform.position;
            var rotation = Quaternion.LookRotation(direction);
            var currentEuler = eaterTransform.rotation.eulerAngles;
            rotation.eulerAngles = new Vector3(currentEuler.x, rotation.eulerAngles.y, currentEuler.z);
            eaterTransform.rotation = Quaternion.Slerp(eaterTransform.rotation, rotation, deltaTime*rotationSpeed);
        }
    }
}