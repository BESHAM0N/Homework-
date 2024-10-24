using ShootEmUp;
using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public class BulletCreator
    {
        private readonly Bullet _bulletPrefab;
        private readonly Transform _container;
        private readonly Queue<Bullet> _bulletPool;

        public BulletCreator(Bullet bulletPrefab, Transform container, Queue<Bullet> bulletPool)
        {
            _bulletPrefab = bulletPrefab;
            _container = container;
            _bulletPool = bulletPool;
        }

        public Bullet GetBullet()
        {
            return _bulletPool.TryDequeue(out var bullet)
                ? bullet
                : CreateNewBullet();
        }

        private Bullet CreateNewBullet()
        {
            return Object.Instantiate(_bulletPrefab, _container);
        }

        public void ReturnBullet(Bullet bullet)
        {
            bullet.transform.SetParent(_container);
            _bulletPool.Enqueue(bullet);
        }
    }
}
