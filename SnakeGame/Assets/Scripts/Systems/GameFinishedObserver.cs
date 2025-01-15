using System;
using Zenject;

namespace SnakeGame
{
    public sealed class GameFinishedObserver : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly IGameUI _gameUI;

        public GameFinishedObserver(IGameCycle gameCycle, IGameUI gameUI)
        {
            _gameCycle = gameCycle ?? throw new ArgumentNullException(nameof(gameCycle));
            _gameUI = gameUI ?? throw new ArgumentNullException(nameof(gameUI));
        }
        
        public void Initialize()
        {
            _gameCycle.OnFinished += _gameUI.GameOver;
        }

        public void Dispose()
        {
            _gameCycle.OnFinished -= _gameUI.GameOver;
        }
    }
}