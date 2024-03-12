using System;

namespace Code.Interfaces
{
    public interface IObjectPlacement
    {
        event Action OnObjectPlaced;
        event Action OnPlacementCancelled;
        void PlaceObject();
        void CancelPlacement();
    }
}