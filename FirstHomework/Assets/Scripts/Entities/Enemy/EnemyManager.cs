using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyManager : MonoBehaviour
    {
        public int ActiveEnemiesCount => _activeEnemies.Count;
        [SerializeField] private PointService _pointService;
        [SerializeField] private EnemyPool _enemyPool;

        private readonly HashSet<Enemy> _activeEnemies = new();

        public void EnemySpawn()
        {
            var spawnPosition = _pointService.GiveRandomSpawnPoint();
            var attackPosition = _pointService.GiveRandomAttackPoint();
            var enemy = _enemyPool.GetObject();
            enemy.Position = spawnPosition.position;
            enemy.Activate(attackPosition.position);
            _activeEnemies.Add(enemy);
        }

        private void FixedUpdate()
        {
            foreach (var enemy in _activeEnemies.ToArray())
            {
                if (enemy.Health <= 0)
                {
                    _enemyPool.ReturnObject(enemy);
                    _activeEnemies.Remove(enemy);
                }
            }
        }
    }

}





