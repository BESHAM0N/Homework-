using UnityEngine;
using Modules;

namespace SnakeGame
{
    public interface ICoinSpawner
    {
        ICoin Fire(Vector2Int position);
        void Despawn(ICoin coin);
    }
}