using UnityEngine;
using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class SnakeMoveController : ITickable
    {
        private readonly ISnake _snake;

        public SnakeMoveController(ISnake snake)
        {
            _snake = snake;
        }

        public void Tick()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _snake.Turn(SnakeDirection.UP);
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                _snake.Turn(SnakeDirection.DOWN);
            }

            if (Input.GetKeyDown(KeyCode.A))
            {
                _snake.Turn(SnakeDirection.LEFT);
            }

            if (Input.GetKeyDown(KeyCode.D))
            {
                _snake.Turn(SnakeDirection.RIGHT);
            }
        }
    }
}