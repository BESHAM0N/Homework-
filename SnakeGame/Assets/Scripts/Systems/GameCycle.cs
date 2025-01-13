using System;
using Modules;

namespace SnakeGame
{
    public sealed class GameCycle : IGameCycle
    {
        private readonly IGameUI _gameUI;
        private readonly CoinManager _coinManager;
        private readonly IDifficulty _difficulty;

        public GameCycle(IGameUI gameUI, CoinManager coinManager, IDifficulty difficulty)
        {
            _gameUI = gameUI ?? throw new ArgumentNullException(nameof(gameUI));
            _coinManager = coinManager ?? throw new ArgumentNullException(nameof(coinManager));
            _difficulty = difficulty ?? throw new ArgumentNullException(nameof(difficulty));
        }

        public void StartGame(int initialCoinCount)
        {
            StartLevel(initialCoinCount);
        }

        private void StartLevel(int coinCount)
        {
            _coinManager.ClearCoins();
            _coinManager.CreateCoins(coinCount);
        }

        public void CheckLevelCompletion()
        {
            if (_difficulty.Next(out int newCoinCount))
            {
                StartLevel(newCoinCount);
            }
        }

        public void OnGameOver(bool win)
        {
            _gameUI.GameOver(win);
        }
    }
}