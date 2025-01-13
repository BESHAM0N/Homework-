using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class DifficultyInstaller : Installer<DifficultyInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<Difficulty>().AsSingle().WithArguments(9).NonLazy();
        }
    }
}