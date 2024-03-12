using Code.Interfaces;
using Code.Services;
using Zenject;

namespace Code.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectSpawner>().To<ObjectSpawnerService>().AsSingle();
            Container.Bind<IObjectFollower>().To<ObjectFollowerService>().AsSingle();
            Container.Bind<IRaycaster>().To<FloorRaycasterService>().AsSingle();
        }
    }
}