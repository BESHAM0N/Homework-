using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private Coin _coinPrefab;
        [SerializeField] private Snake _snakePrefab;
        [SerializeField] private Transform _poolTransform;

        public override void InstallBindings()
        {
            WorldBoundsInstaller.Install(Container);
            CoinInstaller.Install(Container, _coinPrefab, _poolTransform);
            ScoreInstaller.Install(Container);
            DifficultyInstaller.Install(Container);
            GameCycleInstaller.Install(Container);
            SnakeInstaller.Install(Container, _snakePrefab);
        }
    }
}