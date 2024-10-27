using UnityEngine;

namespace ShootEmUp
{
    public class AttackBehavior
    {
        private Transform _firePoint;
        private readonly float _countdown = 1f;
        private float _currentTime;
        private int _damage;
        private BulletManager _bulletManager;
        private readonly int _valueVelosity = 2;
        private readonly Color _bulletColor = Color.red;

        public AttackBehavior(Transform firePoint, BulletManager bulletManager, int damage)
        {
            _firePoint = firePoint;
            _bulletManager = bulletManager;
            _damage = damage;
            ResetAttackTimer();
        }

        public void Attack(Player target)
        {
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire(target);
                ResetAttackTimer();
            }
        }

        private void Fire(Player target)
        {
            Vector2 startPosition = _firePoint.position;
            var direction = ((Vector2)target.transform.position - startPosition).normalized;
            _bulletManager.SpawnBullet(_firePoint.position, _bulletColor, (int)PhysicsLayer.ENEMY_BULLET, _damage, direction * _valueVelosity);
        }

        private void ResetAttackTimer()
        {
            _currentTime = _countdown;
        }
    }
}