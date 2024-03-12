using UnityEngine;

namespace Code.Controllers
{
    public class CubeController : MonoBehaviour
    {
        [SerializeField] private Rigidbody rigidbody;

        public void Release()
        {
            rigidbody.useGravity = true;
        }
    }
}
