using Code.Interfaces;
using UnityEngine;
using Zenject;

namespace Code.Controllers
{
    public class InputController : MonoBehaviour
    {
        [Inject] IObjectPlacement objectPlacement;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                objectPlacement.CancelPlacement();
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                objectPlacement.PlaceObject();
            }
        }
    }
}