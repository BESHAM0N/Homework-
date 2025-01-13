using Modules;
using System;
using Zenject;

namespace SnakeGame
{
    public class UILevelObserver : IInitializable, IDisposable
    {
        private IDifficulty _difficulty;
        private IGameUI _gameUI;

        public UILevelObserver(IDifficulty difficulty, IGameUI gameUI)
        {
            _difficulty = difficulty;
            _gameUI = gameUI;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += UpdateLevel;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= UpdateLevel;
        }

        private void UpdateLevel()
        {
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}