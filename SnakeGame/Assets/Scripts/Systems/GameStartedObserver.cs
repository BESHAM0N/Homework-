using System;
using Zenject;

namespace SnakeGame
{
    public class GameStartedObserver : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly CoinManager _coinManager;

        public GameStartedObserver(IGameCycle gameCycle, CoinManager coinManager)
        {
            _gameCycle = gameCycle ?? throw new ArgumentNullException(nameof(gameCycle));
            _coinManager = coinManager ?? throw new ArgumentNullException(nameof(coinManager));
        }
        
        public void Initialize()
        {
            _coinManager.OnAllCoinsCollected +=  _gameCycle.StartGame;
        }

        public void Dispose()
        {
            _coinManager.OnAllCoinsCollected -=  _gameCycle.StartGame;
        }
    }
}