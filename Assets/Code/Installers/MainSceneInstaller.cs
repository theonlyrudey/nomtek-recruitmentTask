using Code.Interfaces;
using Code.Services;
using Zenject;

namespace Code.Installers
{
    public class MainSceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IObjectsListUI>().To<ObjectsListUIService>().AsSingle();
            Container.Bind<IObjectSpawner>().To<ObjectSpawnerService>().AsSingle();
            Container.Bind<IObjectPlacement>().To<ObjectPlacementService>().AsSingle();
            Container.Bind<IEdiblesHolder>().To<EdiblesHolderService>().AsSingle().NonLazy();
            Container.Bind<ITransformFollower>().To<TransformFollowerService>().AsSingle();
            Container.Bind<IObjectsLoader>().To<ObjectsLoaderService>().AsSingle();
            Container.Bind<ITextFilter>().To<TextFilterService>().AsSingle();
        }
    }
}