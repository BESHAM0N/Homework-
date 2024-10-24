using UnityEngine;

namespace ShootEmUp
{
    public sealed class Enemy : MonoBehaviour, IDamageable
    {
        public delegate void FireHandler(Vector2 position, Vector2 direction);
        public event FireHandler OnFire;

        public int Health => _health;

        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _speed = 5.0f;

        private Player _target;
        private Vector2 _destination;
        private Rigidbody2D _rigidbody;
        private int _health = 1;
        private MovementBehavior _movementBehavior;
        private AttackBehavior _attackBehavior;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _movementBehavior = new MovementBehavior(_rigidbody, _speed);
            _attackBehavior = new AttackBehavior(this, _firePoint);
        }

        private void Start()
        {
            SetTarget();
        }

        private void SetTarget()
        {
            var obj = GameObject.FindGameObjectWithTag("Player");
            if (obj != null)
                _target = obj.GetComponent<Player>();
            else
                Debug.Log("Player не найден");
        }

        private void FixedUpdate()
        {
            if (_target != null && _target.Health > 0)
            {
                if (_movementBehavior.IsPointReached)
                    _attackBehavior.Attack(_target);
                else
                    _movementBehavior.Move(_target.transform.position);
            }
        }

        public void RequestAttack(Vector2 position, Vector2 direction)
        {
            OnFire?.Invoke(position, direction);
        }

        public void Activate(Vector2 destination)
        {
            _health = 1;
            _movementBehavior.SetDestination(destination);
            gameObject.SetActive(true);
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;

            if (_health <= 0)
                gameObject.SetActive(false);
        }

        public void ResetEnemy()
        {
            _health = 1;
            SetTarget();
            gameObject.SetActive(true);
        }
    }
}






