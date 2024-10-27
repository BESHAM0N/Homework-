using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Ship : MonoBehaviour, IDamageable
    {
        public Action OnHealthEmpty;
        public int Health => _health;

        [SerializeField] protected Transform _firePoint;
        [SerializeField] protected float _speed = 5.0f;
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected bool _isEnemy;
        [SerializeField] protected int _health;
        [SerializeField] protected int _maxHealth = 3;
        protected Rigidbody2D _rigidbody;

        public void TakeDamage(int amount)
        {
            _health = Mathf.Max(0, _health - amount);
            if (_health <= 0)
            {
                if (_isEnemy)
                    gameObject.SetActive(false);
                else
                    OnHealthEmpty?.Invoke();
            }
        }
    }
}