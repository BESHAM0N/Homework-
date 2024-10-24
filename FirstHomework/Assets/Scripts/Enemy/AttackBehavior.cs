using UnityEngine;

namespace ShootEmUp
{
    public class AttackBehavior
    {
        private Transform _firePoint;
        private Enemy _enemy;
        private float _countdown = 1f;
        private float _currentTime;

        public AttackBehavior(Enemy enemy, Transform firePoint)
        {
            _enemy = enemy;
            _firePoint = firePoint;
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
            _enemy.RequestAttack(_firePoint.position, direction);
        }

        private void ResetAttackTimer()
        {
            _currentTime = _countdown;
        }
    }

}