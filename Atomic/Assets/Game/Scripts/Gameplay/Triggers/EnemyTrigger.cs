using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    [RequireComponent(typeof(Collider))]
    public sealed class EnemyTrigger : MonoBehaviour
    {
        [SerializeField] private SceneEntity[] _enemies;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity target))
                return;
           
            foreach (var enemy in _enemies)
            {
                if (!enemy.HasTarget()) continue;
                enemy.GetTarget().Value = target;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity target))
                return;

            foreach (var enemy in _enemies)
            {
                if (!enemy.HasTarget()) continue;
                if (enemy.GetTarget().Value == target)
                    enemy.GetTarget().Value = null;
            }
        }
    }
}