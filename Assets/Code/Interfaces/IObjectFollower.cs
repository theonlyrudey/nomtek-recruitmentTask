using UnityEngine;

namespace Code.Interfaces
{
    public interface IObjectFollower 
    {
        void UpdatePosition(Vector3 newPosition);
        void ReleaseObject();
    }
}