using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakePickUpCoinsObserver : IInitializable, IDisposable
    {
        private ISnake _snake;
        private CoinManager _coinManager;

        public SnakePickUpCoinsObserver(ISnake snake, CoinManager coinManager)
        {
            _snake = snake;
            _coinManager = coinManager;
        }

        public void Initialize()
        {
            _snake.OnMoved += _coinManager.PickUp;
        }

        public void Dispose()
        {
            _snake.OnMoved -= _coinManager.PickUp;
        }
    }
}