using UnityEngine;
using Zenject;

namespace SnakeGame
{
    public class EntryPoint : MonoBehaviour
    {
        [Inject] private IGameCycle _gameCycle;

        private void Start()
        {
            _gameCycle.StartGame();
        }
    }
}