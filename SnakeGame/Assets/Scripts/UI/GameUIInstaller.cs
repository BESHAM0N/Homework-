using Zenject;

namespace SnakeGame
{
    public class GameUIInstaller : Installer<GameUIInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameUI>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameUIInitializer>().AsSingle();
            Container.BindInterfacesAndSelfTo<UILevelObserver>().AsSingle();
            Container.BindInterfacesAndSelfTo<UIScoreObserver>().AsSingle();
        }
    }
}