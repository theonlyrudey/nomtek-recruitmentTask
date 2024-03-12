using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class FloorRaycasterService : IRaycaster
    {
        private int floorMask = LayerMask.GetMask("Floor");
        private Transform startTransform;
        
        public void Init(Transform startTransform)
        {
            this.startTransform = startTransform;
        }
        
        public Vector3 GetPoint()
        {
            var ray = new Ray(startTransform.position, Vector3.down);
            return Physics.Raycast(ray, out var hit, Mathf.Infinity, floorMask) ? hit.point : Vector3.zero;
        }
    }
}