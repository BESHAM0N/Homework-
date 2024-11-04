using UnityEngine;

namespace ShootEmUp
{
    public sealed class EnemyPool : ObjectPool<Enemy>
    {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private BulletManager _bulletManager;

        protected override void OnGetObject(Enemy enemy)
        {
            enemy.Ship.SetBulletManager(_bulletManager);
            enemy.SetParent(_worldTransform);
            enemy.ResetEnemy();
            enemy.gameObject.SetActive(true);
        }
    }
}


