using Code.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Controllers
{
    public class MouseFollowController : MonoBehaviour
    {
        [SerializeField] private Camera mainCamera;
        [Inject] private ITransformFollower transformFollower;
        [Inject] private IObjectSpawner objectSpawner;
        [Inject] private IObjectPlacement objectPlacement;

        private int floorMask;
        private Vector3 newPosition = Vector3.zero;
        private void Awake()
        {
            floorMask = LayerMask.GetMask("Floor");
            objectSpawner.OnObjectSpawned += OnObjectSpawned;
            objectPlacement.OnObjectPlaced += ReleaseObject;
            objectPlacement.OnPlacementCancelled += ReleaseObject;
        }

        private void OnObjectSpawned(GameObject obj)
        {
            transformFollower.AssignTransform(obj.transform);
            newPosition = obj.transform.position;
        }

        private void ReleaseObject(GameObject obj)
        {
            transformFollower.ReleaseObject();
        }
        
        private void Update()
        {
            if (mainCamera == null || !transformFollower.IsFollowing) return;
            var mousePosition = Input.mousePosition;
            var mouseRay = mainCamera.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(mouseRay, out var hit, Mathf.Infinity, floorMask))
            {
                newPosition = hit.point;
            }
            transformFollower.UpdatePosition(newPosition);
        }

        private void OnDestroy()
        {
            transformFollower.ReleaseObject();
        }
    }
}
