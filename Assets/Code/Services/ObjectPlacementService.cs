using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class ObjectPlacementService : IObjectPlacement
    {
        public event Action<GameObject> OnObjectPlaced;
        public event Action<GameObject> OnPlacementCancelled;

        private IPlaceableObject placeableObject;
        private GameObject placeableObjectGameObject;
        
        public ObjectPlacementService(IObjectSpawner objectSpawner)
        {
            objectSpawner.OnObjectSpawned += AssignPlaceableObject;
        }
        
        public void PlaceObject()
        {
            if(placeableObject == null) return;
            placeableObject.Place();
            OnObjectPlaced?.Invoke(placeableObjectGameObject);
        }

        public void CancelPlacement()
        {
            if(placeableObject == null) return;
            placeableObject.CancelPlacement();
            OnPlacementCancelled?.Invoke(placeableObjectGameObject);
        }

        private void AssignPlaceableObject(GameObject obj)
        {
            placeableObjectGameObject = obj;
            var placeableObject = obj.GetComponent<IPlaceableObject>();
            if (placeableObject == null) return;
            this.placeableObject = placeableObject;
        }
    }
}