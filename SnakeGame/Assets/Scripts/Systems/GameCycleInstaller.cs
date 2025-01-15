using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameCycleInstaller : Installer<GameCycleInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameStartedObserver>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<LoadLevelController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameFinishedObserver>().AsSingle().NonLazy();
        }
    }
}