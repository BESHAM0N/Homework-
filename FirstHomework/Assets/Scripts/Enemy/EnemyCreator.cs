using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyCreator
    {
        private readonly Enemy _enemyPrefab;
        private readonly Transform _worldTransform;
        private readonly Transform _container;

        private readonly Queue<Enemy> _enemyPool;

        public EnemyCreator(Enemy enemyPrefab, Transform worldTransworm, Transform container, Queue<Enemy> enemyPool)
        {
            _enemyPrefab = enemyPrefab;
            _worldTransform = worldTransworm;
            _container = container;
            _enemyPool = enemyPool;
        }

        public Enemy GetOrCreateEnemy(Vector2 spawnPosition)
        {
            Enemy enemy = _enemyPool.Count > 0 ? _enemyPool.Dequeue() : Object.Instantiate(_enemyPrefab, _container);
            enemy.transform.SetParent(_worldTransform);
            enemy.transform.position = spawnPosition;
            enemy.ResetEnemy(); 
            return enemy;
        }

        public void ReturnEnemy(Enemy enemy)
        {           
            enemy.gameObject.SetActive(false);
            _enemyPool.Enqueue(enemy);
        }
    }
}
