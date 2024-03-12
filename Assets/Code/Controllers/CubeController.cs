using Code.Interfaces;
using UnityEngine;

namespace Code.Controllers
{
    public class CubeController : MonoBehaviour, IPlaceableObject
    {
        [SerializeField] private Rigidbody rigidbody;

        public void Place()
        {
            rigidbody.useGravity = true;
            rigidbody.constraints = RigidbodyConstraints.None;
        }

        public void CancelPlacement()
        {
            Destroy(gameObject);
        }
    }
}
