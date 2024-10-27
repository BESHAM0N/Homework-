using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : ObjectPool<Enemy>
    {
        [SerializeField] private Transform _worldTransform;

        public Enemy GetOrCreateEnemy(Vector2 spawnPosition)
        {
            Enemy enemy = GetObject();
            enemy.SetParent(_worldTransform);
            enemy.Position = spawnPosition;
            enemy.ResetEnemy();
            enemy.gameObject.SetActive(true);
            return enemy;
        }

        public void ReturnEnemy(Enemy enemy)
        {
            ReturnObject(enemy);
        }
    }
}


