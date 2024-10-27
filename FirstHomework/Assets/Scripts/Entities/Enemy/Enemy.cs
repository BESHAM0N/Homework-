using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : Ship
    {
        public Vector2 Position
        {
            set => transform.position = value;
        }

        private Player _target;
        private Vector2 _destination;
        private BulletManager _bulletManager;
        
        private MovementBehavior _movementBehavior;
        private AttackBehavior _attackBehavior;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movementBehavior = new MovementBehavior(_rigidbody, _speed);
            SetTarget();
        }

        private void SetTarget()
        {
            var obj = GameObject.FindGameObjectWithTag("Player");
            if (obj != null)
                _target = obj.GetComponent<Player>();
            else
                Debug.Log("Player not found");
        }

        private void FixedUpdate()
        {
            if (_target != null && _target.Health > 0)
            {
                if (_movementBehavior.IsPointReached)
                    _attackBehavior.Attack(_target);
                else
                    _movementBehavior.Move();
            }
        }

        public void Activate(Vector2 destination, BulletManager bulletManager)
        {
            _health = _maxHealth;
            _movementBehavior.SetDestination(destination);
            _bulletManager = bulletManager;
            _attackBehavior = new AttackBehavior(_firePoint, _bulletManager, _damage);
            gameObject.SetActive(true);
        }

        public void SetParent(Transform parent)
        {
            transform.parent = parent;
        }

        public void ResetEnemy()
        {
            _health = _maxHealth;
            SetTarget();
            gameObject.SetActive(true);
        }
    }
}