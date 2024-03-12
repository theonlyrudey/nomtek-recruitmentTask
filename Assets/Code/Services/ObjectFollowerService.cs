using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class ObjectFollowerService : IObjectFollower {
        private GameObject currentObject;

        public void UpdatePosition(Vector3 newPosition) {
            if(currentObject != null) {
                currentObject.transform.position = newPosition;
            }
        }

        public void ReleaseObject() {
            currentObject = null;
        }
        
        public void AssignObject(GameObject obj) {
            currentObject = obj;
        }
    }
}