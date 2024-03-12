using UnityEngine;

namespace Code.Interfaces
{
    public interface ITransformFollower 
    {
        void UpdatePosition(Vector3 newPosition);
        void ReleaseObject();
        void AssignTransform(Transform transform);
        bool IsFollowing { get; }
    }
}