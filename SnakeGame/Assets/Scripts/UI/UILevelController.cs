using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public class UILevelController : IInitializable, IDisposable
    {
        private IDifficulty _difficulty;
        private IGameUI _gameUI;

        public UILevelController(IDifficulty difficulty, IGameUI gameUI)
        {
            _difficulty = difficulty;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += UpdateLevel;
            StartSetLevel();
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= UpdateLevel;
        }

        private void UpdateLevel()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }

        private void StartSetLevel()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}