using System;

namespace SnakeGame
{
    public interface IGameCycle
    {
        event Action OnStarted;
        event Action<bool> OnFinished;
        
        public void StartGame();
        public void FinishGame(bool win);
    }
}