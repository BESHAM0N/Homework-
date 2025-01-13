using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class ScoreIncreaseObserver : IInitializable, IDisposable
    {
        private readonly IScore _score;
        private readonly CoinManager _coinManager;
        
        public ScoreIncreaseObserver(IScore score, CoinManager coinManager)
        {
            _score = score ?? throw new ArgumentNullException(nameof(score));
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
            _score.Add(coin.Score);
        }
    }
}