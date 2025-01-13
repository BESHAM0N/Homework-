using Zenject;

namespace SnakeGame
{
    public sealed class WorldBoundsInstaller : Installer<WorldBoundsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<IWorldBounds>().FromComponentInHierarchy().AsSingle().NonLazy();
        }
    }
}