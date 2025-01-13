using System;
using Zenject;

namespace SnakeGame
{
    public class GameCycleObserver : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly CoinManager _coinManager;

        public GameCycleObserver(IGameCycle gameCycle, CoinManager coinManager)
        {
            _gameCycle = gameCycle;
            _coinManager = coinManager;
        }
        
        public void Initialize()
        {
            _coinManager.OnGameOver += _gameCycle.OnGameOver;
            _coinManager.OnLevelCompleted +=  _gameCycle.CheckLevelCompletion;
        }

        public void Dispose()
        {
            _coinManager.OnGameOver -= _gameCycle.OnGameOver;
            _coinManager.OnLevelCompleted -=  _gameCycle.CheckLevelCompletion;
        }
    }
}