using Code.Data;
using UnityEngine;
using Zenject;

namespace Code.Installers
{
    [CreateAssetMenu(fileName = "MainScriptableObjectsInstaller", menuName = "Installers/MainScriptableObjectsInstaller")]
    public class MainScriptableObjectsInstaller : ScriptableObjectInstaller<MainScriptableObjectsInstaller>
    {
        [SerializeField] private ObjectsContainer objectsContainer;
        
        public override void InstallBindings()
        {
            Container.BindInstance(objectsContainer);
        }
    }
}