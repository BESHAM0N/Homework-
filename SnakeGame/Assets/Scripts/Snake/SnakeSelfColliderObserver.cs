using System;
using Modules;
using Zenject;

namespace SnakeGame
{
    public class SnakeSelfColliderObserver : IInitializable, IDisposable
    {
        private ISnake _snake;
        private IGameCycle _gameCycle;

        public SnakeSelfColliderObserver(ISnake snake, IGameCycle gameCycle)
        {
            _snake = snake;
            _gameCycle = gameCycle;
        }

        public void Initialize()
        {
            _snake.OnSelfCollided += OnSelfCollider;
        }

        public void Dispose()
        {
            _snake.OnSelfCollided -= OnSelfCollider;
        }
        
        private void OnSelfCollider()
        {
            _gameCycle.FinishGame(false);
        }
    }
}

