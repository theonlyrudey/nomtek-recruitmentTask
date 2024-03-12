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
        }

        private void ReleaseObject()
        {
            transformFollower.ReleaseObject();
        }
        
        private void Update()
        {
            if (mainCamera == null || !transformFollower.IsFollowing) return;
            var mousePosition = Input.mousePosition;
            var mouseRay = mainCamera.ScreenPointToRay(mousePosition);
            Debug.DrawRay(mouseRay.origin, mouseRay.direction * 100, Color.red);
            if (!Physics.Raycast(mouseRay, out var hit,Mathf.Infinity,floorMask)) return;

            var newPosition = hit.point;
            transformFollower.UpdatePosition(newPosition);
        }

        private void OnDestroy()
        {
            transformFollower.ReleaseObject();
        }
    }
}
