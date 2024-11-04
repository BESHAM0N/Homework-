using UnityEngine;

namespace ShootEmUp
{
    public class AttackBehavior
    {
        private readonly float _countdown = 1f;
        private float _currentTime;
        private Ship _ship;

        public AttackBehavior(Ship ship)
        {
            _ship = ship;            
            ResetAttackTimer();
        }

        public void Attack(Ship target)
        {
            _currentTime -= Time.fixedDeltaTime;
            if (_currentTime <= 0)
            {
                Fire(target);
                ResetAttackTimer();
            }
        }

        private void Fire(Ship target)
        {
            _ship.AttackAt(target.transform.position);            
        }

        private void ResetAttackTimer()
        {
            _currentTime = _countdown;
        }
    }
}