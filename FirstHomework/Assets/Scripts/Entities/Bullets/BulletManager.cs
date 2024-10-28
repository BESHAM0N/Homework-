using System.Collections.Generic;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class BulletManager : MonoBehaviour
    {
        [SerializeField] private Transform _worldTransform;
        [SerializeField] private LevelBounds _levelBounds;
        [SerializeField] private BulletPool _bulletPool;
        private readonly HashSet<Bullet> _activeBullets = new();
        private readonly List<Bullet> _cache = new();

        private void FixedUpdate()
        {
            _cache.Clear();
            _cache.AddRange(_activeBullets);

            foreach (var bullet in _cache)
            {
                if (!_levelBounds.InBounds(bullet.Position))                
                    RemoveBullet(bullet);                
            }
        }

        public void SpawnBullet(Vector2 position, Color color, int physicsLayer, int damage, Vector2 velocity)
        {
            //var bullet = _bulletPool.GetObject();
            //bullet.SetParent(_worldTransform);
            //bullet.Position = position;
            //bullet.Initialize(color, physicsLayer, damage, velocity);

            //if (_activeBullets.Add(bullet))
            //{
            //    bullet.OnCollisionEntered += OnBulletCollision;
            //}

            var bullet = _bulletPool.GetObject();
            bullet.Spawn(position, color, physicsLayer, damage, velocity, _worldTransform);

            if (_activeBullets.Add(bullet))
            {
                bullet.OnCollisionEntered += OnBulletCollision;
            }
        }

        private void OnBulletCollision(Bullet bullet, Collision2D collision)
        {
            RemoveBullet(bullet);
        }

        private void RemoveBullet(Bullet bullet)
        {
            if (_activeBullets.Remove(bullet))
            {
                bullet.OnCollisionEntered -= OnBulletCollision;
                _bulletPool.ReturnObject(bullet);
            }
        }

    }
}