using Modules;
using Zenject;

namespace SnakeGame
{
    public class GameCycleInstaller : Installer<GameCycleInstaller>
    {
        private const int INITIAL_QUANTITY = 1;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameCycle>().AsSingle().OnInstantiated<GameCycle>((_, gameCycle) =>
            {
                gameCycle.StartGame(INITIAL_QUANTITY);
            });
            Container.BindInterfacesAndSelfTo<GameCycleObserver>().AsSingle().NonLazy();
        }
    }
}