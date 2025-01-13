namespace SnakeGame
{
    public interface IGameCycle
    {
        public void CheckLevelCompletion();
        public void OnGameOver(bool win);
    }
}