using System;
using UnityEngine;

namespace Component
{
    public class LifeComponent : MonoBehaviour, IDamageable
    {
        public event Action OnEmpty;
        public event Action OnHit;

        [SerializeField] private int _maxPoints;
        [SerializeField] private bool _isDead;
        [SerializeField] private int _hitPoints;

        private void Start()
        {
            _hitPoints = _maxPoints;
        }

        public void TakeDamage(int damage)
        {
            if (_isDead)
            {
                return;
            }

            _hitPoints -= damage;
            OnHit?.Invoke();
            
            if (_hitPoints <= 0)
            {
                _isDead = true;
                OnEmpty?.Invoke();
            }
        }

        public bool IsAlive()
        {
            return !_isDead;
        }
    }
}