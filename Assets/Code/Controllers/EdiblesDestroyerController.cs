using Code.Interfaces;
using UnityEngine;

namespace Code.Controllers
{
    public class EdiblesDestroyerController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var edible = other.GetComponent<IEdible>();
            edible?.GetEaten();
        }
    }
}
