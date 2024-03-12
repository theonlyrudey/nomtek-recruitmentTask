using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class TransformFollowerService : ITransformFollower
    {
        private Transform currentObject;

        public bool IsFollowing => currentObject != null;
        
        public void UpdatePosition(Vector3 newPosition)
        {
            if (currentObject != null)
            {
                currentObject.position = newPosition;
            }
        }

        public void ReleaseObject()
        {
            currentObject = null;
        }

        public void AssignTransform(Transform obj)
        {
            currentObject = obj;
        }
    }
}