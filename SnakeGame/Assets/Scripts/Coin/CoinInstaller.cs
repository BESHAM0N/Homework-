using Modules;
using Zenject;
using UnityEngine;

namespace SnakeGame
{
    public sealed class CoinInstaller : Installer<Coin, Transform, CoinInstaller>
    {
        private Coin _coinPrefab;
        private Transform _worldTransform;

        private const int INITIAL_SIZE = 1;
        private const int MAX_SIZE = 10;

        [Inject]
        public void Construct(Coin coinPrefab, Transform worldTransform)
        {
            _coinPrefab = coinPrefab;
            _worldTransform = worldTransform;
        }

        public override void InstallBindings()
        {
            Container
                .BindMemoryPool<Coin, CoinPool>()
                .WithInitialSize(INITIAL_SIZE)
                .WithMaxSize(MAX_SIZE)
                .ExpandByOneAtATime()
                .FromComponentInNewPrefab(_coinPrefab)
                .WithGameObjectName("Coin")
                .UnderTransform(_worldTransform)
                .AsSingle();

            Container
                .Bind<ICoinSpawner>()
                .To<CoinPool>()
                .FromResolve();
            
            Container.Bind<CoinManager>().AsSingle();
        }
    }
}