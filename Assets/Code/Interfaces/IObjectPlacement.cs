using System;
using UnityEngine;

namespace Code.Interfaces
{
    public interface IObjectPlacement
    {
        event Action<GameObject> OnObjectPlaced;
        event Action<GameObject> OnPlacementCancelled;
        void PlaceObject();
        void CancelPlacement();
    }
}