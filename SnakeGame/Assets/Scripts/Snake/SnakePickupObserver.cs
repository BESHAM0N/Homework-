using System;
using Modules;
using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakePickupObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public SnakePickupObserver(ISnake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += OnMoved;
        }

        public void Dispose()
        {
            _snake.OnMoved -= OnMoved;
        }

        private void OnMoved(Vector2Int position)
        {
            Debug.Log(_coinManager.TryPickUp(position) ? "Coin is picked up." : "This position has no coin.");
        }
    }
}