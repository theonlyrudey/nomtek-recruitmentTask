using System;
using Code.Interfaces;
using UnityEngine;

namespace Code.Controllers
{
    public class CubeController : MonoBehaviour, IPlaceableObject, IEdible
    {
        [SerializeField] private Rigidbody rigidbody;
        
        public bool Initialized { get; private set; }
        public event Action<IEdible> OnEaten;
        
        public void Place()
        {
            if(rigidbody == null) return;
            Initialized = true;
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.None;
        }

        public void CancelPlacement()
        {
            Destroy(gameObject);
        }

        public void GetEaten()
        {
            if(!Initialized) return;
            OnEaten?.Invoke(this);
            Destroy(gameObject);
        }

        public Vector3 Position => transform.position;
    }
}
