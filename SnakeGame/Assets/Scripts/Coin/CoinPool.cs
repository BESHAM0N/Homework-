using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class CoinPool : MonoMemoryPool<Vector2Int, Coin>, ICoinSpawner
    {
        ICoin ICoinSpawner.Fire(Vector2Int position)
        {
            return Spawn(position);
        }
        
        void ICoinSpawner.Despawn(ICoin coin)
        {
            Despawn((Coin)coin);
        }
        
        protected override void Reinitialize(Vector2Int position, Coin coin)
        {
            coin.Position = position;
            coin.Generate();
        }
       
        protected override void OnSpawned(Coin coin)
        {
            base.OnSpawned(coin);
        }
        
        protected override void OnDespawned(Coin coin)
        {
            base.OnDespawned(coin);
            coin.Position = Vector2Int.zero;
        }
    }
}