using System;

namespace SnakeGame
{
    public sealed class GameCycle : IGameCycle
    {
        public event Action OnStarted;
        public event Action<bool> OnFinished;

        public void StartGame()
        {
            OnStarted.Invoke();
        }

        public void FinishGame(bool win)
        {
            OnFinished.Invoke(win);
        }
    }
}