using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletController : MonoBehaviour
    {
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private Transform _container;

        private BulletCreator _bulletCreator;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly Queue<Bullet> _bulletPool = new();
        private readonly List<Bullet> _cache = new();

        private void Awake()
        {
            _bulletCreator = new BulletCreator(_bulletPrefab, _container, _bulletPool);
            GenerateBulletPool(10);
        }

        private void GenerateBulletPool(int poolSize)
        {
            for (var i = 0; i < poolSize; i++)
            {
                _bulletPool.Enqueue(_bulletCreator.GetBullet());
            }
        }

        private void FixedUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            foreach (var bullet in _cache)
            {
                if (!_levelBounds.InBounds(bullet.transform.position))                
                    RemoveBullet(bullet);                
            }
        }

        public void SpawnBullet(Vector2 position, Color color, int physicsLayer, int damage, bool isPlayer, Vector2 velocity)
        {
            var bullet = _bulletCreator.GetBullet();
            bullet.transform.SetParent(_worldTransform);
            bullet.transform.position = position;
            bullet.Initialize(color, physicsLayer, damage, velocity);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            bullet.HandleCollision(collision);
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletCreator.ReturnBullet(bullet);
            }
        }

    }
}