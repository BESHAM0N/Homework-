using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Ship : MonoBehaviour, IDamageable
    {
        public Action OnHealthEmpty;
        [SerializeField] private BulletManager _bulletManager;
        public int Health => _health;
        
        [SerializeField] protected Transform _firePoint;
        [SerializeField] protected float _speed = 5.0f;
        [SerializeField] protected int _damage = 1;
        [SerializeField] protected bool _isEnemy;
        [SerializeField] protected int _health;
        [SerializeField] protected int _maxHealth;
        [SerializeField] private Color _bulletColor;
        [SerializeField] private int _valueVelocity;
        [SerializeField] private PhysicsLayer _physicsLayer;
        protected Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void SetBulletManager(BulletManager bulletManager)
        {
            _bulletManager = bulletManager;
        }

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

        public virtual void Move(Vector2 direction)
        {             
            if (direction.magnitude > 0)
            {
                var moveStep = direction.normalized * Time.fixedDeltaTime * _speed;
                var targetPosition = _rigidbody.position + moveStep;
                _rigidbody.MovePosition(targetPosition);
            }
        }

        public virtual void AttackAt(Vector2 targetPosition)
        {
            var vector = targetPosition - (Vector2)_firePoint.position;
            Attack(vector.normalized);
        }
        
        public virtual void Attack(Vector2 direction)
        {
            _bulletManager.SpawnBullet(_firePoint.position, _bulletColor, (int)_physicsLayer, _damage, direction * _valueVelocity);
        }
        
        public Vector2 CalculateDirectionTo(Vector2 target)
        {
            return target - _rigidbody.position;
        }

        public void ResetShip()
        {
            _health = _maxHealth;
            gameObject.SetActive(true);
        }
    }
}