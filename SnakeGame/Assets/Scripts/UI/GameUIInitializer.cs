using Modules;
using Zenject;

namespace SnakeGame
{
    public sealed class GameUIInitializer : IInitializable
    {
        private IGameUI _gameUI;
        private IScore _score;
        private IDifficulty _difficulty;

        public GameUIInitializer(IGameUI gameUI, IScore score, IDifficulty difficulty)
        {
            _gameUI = gameUI;
            _score = score;
            _difficulty = difficulty;
        }

        public void Initialize()
        {
            _gameUI.SetScore(_score.Current.ToString());
            _gameUI.SetDifficulty(_difficulty.Current, _difficulty.Max);
        }
    }
}