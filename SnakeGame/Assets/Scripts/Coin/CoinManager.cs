using System;
using System.Collections.Generic;
using Modules;
using UnityEngine;

namespace SnakeGame
{
    public sealed class CoinManager
    {
        public event Action<ICoin> OnCoinPickedUp;
        public event Action OnAllCoinsCollected;
        
        private readonly IWorldBounds _worldBounds;
        private readonly ICoinSpawner _coinPool;
        
        private readonly List<ICoin> _activeCoins = new();

        public CoinManager(IWorldBounds worldBounds, ICoinSpawner coinPool)
        {
            _worldBounds = worldBounds ?? throw new ArgumentNullException(nameof(worldBounds));
            _coinPool = coinPool ?? throw new ArgumentNullException(nameof(coinPool));
        }

        public void ClearCoins()
        {
            _activeCoins.Clear();
        }

        public void CreateCoins(int cout)
        {
            for (var i = 0; i < cout; i++)
            {
                var position = _worldBounds.GetRandomPosition();
                var coin = _coinPool.Fire(position);
                if (coin != null)
                {
                    AddCoin(coin);
                }
            }
        }

        private void AddCoin(ICoin coin)
        {
            _activeCoins.Add(coin);
        }

        public bool TryPickUp(Vector2Int position)
        {
            foreach (var coin in _activeCoins.ToArray())
            {
                if (coin.Position != position) continue;
                
                OnCoinPickedUp?.Invoke(coin);

                _coinPool.Despawn(coin);
                _activeCoins.Remove(coin);

                if (_activeCoins.Count == 0)
                {
                     OnAllCoinsCollected?.Invoke();
                }

                return true;
            }
            return false;
        }
    }
}