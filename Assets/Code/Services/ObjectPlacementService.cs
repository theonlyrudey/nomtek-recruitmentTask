using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Services
{
    public class ObjectPlacementService : IObjectPlacement
    {
        public event Action OnObjectPlaced;
        public event Action OnPlacementCancelled;

        private IPlaceableObject placeableObject;
        
        public ObjectPlacementService(IObjectSpawner objectSpawner)
        {
            objectSpawner.OnObjectSpawned += AssignPlaceableObject;
        }
        
        public void PlaceObject()
        {
            if(placeableObject == null) return;
            placeableObject.Place();
            OnObjectPlaced?.Invoke();
        }

        public void CancelPlacement()
        {
            if(placeableObject == null) return;
            placeableObject.CancelPlacement();
            OnPlacementCancelled?.Invoke();
        }

        private void AssignPlaceableObject(GameObject obj)
        {
            var placeableObject = obj.GetComponent<IPlaceableObject>();
            if (placeableObject == null) return;
            this.placeableObject = placeableObject;
        }
    }
}