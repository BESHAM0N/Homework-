using System;
using Zenject;
using Modules;

namespace SnakeGame
{
    public sealed class UIScoreObserver : IInitializable, IDisposable
    {
        private IScore _score;
        private IGameUI _gameUI;

        public UIScoreObserver(IScore score, IGameUI gameUI)
        {
            _score = score;
            _gameUI = gameUI;
        }
        
        public void Initialize()
        {
            _score.OnStateChanged += UpdateScore;
        }
        
        public void Dispose()
        {
            _score.OnStateChanged -= UpdateScore;
        }
        private void UpdateScore(int score)
        {
            _gameUI.SetScore(score.ToString());
        }
    }
}