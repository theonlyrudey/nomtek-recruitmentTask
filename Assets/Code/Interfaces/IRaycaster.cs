using UnityEngine;

namespace Code.Interfaces
{
    public interface IRaycaster
    {
        void Init(Transform startTransform);
        Vector3 GetPoint();
    }
}