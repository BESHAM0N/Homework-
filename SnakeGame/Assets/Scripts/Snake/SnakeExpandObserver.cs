using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeExpandObserver : IInitializable, IDisposable
    {
        private readonly ISnake _snake;
        private readonly CoinManager _coinManager;

        public SnakeExpandObserver(ISnake snake, CoinManager coinManager)
        {
            _snake = snake ?? throw new ArgumentNullException(nameof(snake));
            _coinManager = coinManager ?? throw new ArgumentNullException(nameof(coinManager));
        }
        
        public void Initialize()
        {
            _coinManager.OnCoinPickedUp += OnCoinPickedUp;
        }

        public void Dispose()
        {
            _coinManager.OnCoinPickedUp -= OnCoinPickedUp;
        }

        private void OnCoinPickedUp(ICoin coin)
        {
            _snake.Expand(coin.Bones);
        }
    }
}