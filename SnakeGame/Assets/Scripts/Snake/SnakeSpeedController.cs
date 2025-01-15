using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeSpeedObserver : IInitializable, IDisposable
    {
        private ISnake _snake;
        private IDifficulty _difficulty;

        public SnakeSpeedObserver(ISnake snake, IDifficulty difficulty)
        {
            _snake = snake;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _difficulty.OnStateChanged += OnDifficultyChanged;
        }

        public void Dispose()
        {
            _difficulty.OnStateChanged -= OnDifficultyChanged;
        }

        private void OnDifficultyChanged()
        {
            _snake.SetSpeed(_difficulty.Current);
        }
    }
}