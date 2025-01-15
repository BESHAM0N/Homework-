using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class LoadLevelController : IInitializable, IDisposable
    {
        private readonly IGameCycle _gameCycle;
        private readonly IDifficulty _difficulty;
        private readonly CoinManager _coinManager;

        public LoadLevelController(IGameCycle gameCycle, IDifficulty difficulty, CoinManager coinManager)
        {
            _gameCycle = gameCycle ?? throw new ArgumentNullException(nameof(gameCycle));
            _difficulty = difficulty ?? throw new ArgumentNullException(nameof(difficulty));
            _coinManager = coinManager ?? throw new ArgumentNullException(nameof(coinManager));
        }

        public void Initialize()
        {
            _gameCycle.OnStarted += LoadLevel;
        }

        public void Dispose()
        {
            _gameCycle.OnStarted -= LoadLevel;
        }

        private void LoadLevel()
        {
            if (_difficulty.Next(out int newCoinCount))
            {
                _coinManager.ClearCoins();
                _coinManager.CreateCoins(newCoinCount);
            }
        }
    }
}