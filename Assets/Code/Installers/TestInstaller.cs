using Code.Interfaces;
using Code.Services;
using Zenject;

namespace Code.Installers
{
    public class TestInstaller : Installer<TestInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectSpawner>().To<ObjectSpawnerService>().AsSingle();
            Container.Bind<ITransformFollower>().To<TransformFollowerService>().AsSingle();
            Container.Bind<IObjectsLoader>().To<ObjectsLoaderService>().AsSingle();
        }
    }
}
