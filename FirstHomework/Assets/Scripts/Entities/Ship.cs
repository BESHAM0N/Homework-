using System;
using UnityEngine;

namespace ShootEmUp
{
    public class Ship : MonoBehaviour, IDamageable
    {
        public Action OnHealthEmpty;
        [SerializeField] private BulletManager _bulletManager;

        public int Health => _health;
        public int Damage => _damage;
        public float Speed => _speed;
        public Transform FirePoint => _firePoint;
        public Color BulletColor => _bulletColor;
        public int ValueVelocity => _valueVelocity;
        public PhysicsLayer PhysicsLayer => _physicsLayer;
        public Rigidbody2D Rigidbody => _rigidbody;

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
            Debug.Log("bulletManager назначен");
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

        public virtual void Move(Vector2 targetPosition)
        {            
            _rigidbody.MovePosition(targetPosition); 
        }

        public virtual void Attack(Vector2 direction)
        {
            _bulletManager.SpawnBullet(_firePoint.position, _bulletColor, (int)_physicsLayer, _damage, direction * _valueVelocity);
        }

        public void ResetShip()
        {
            _health = _maxHealth;
            gameObject.SetActive(true);
        }
        
    }
}