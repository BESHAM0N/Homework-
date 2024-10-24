using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : MonoBehaviour, IDamageable
    {
        public Action<Player, int> OnHealthChanged;
        public Action<Player> OnHealthEmpty;
        public event Action OnAttackRequested;
        public event Action<float> OnMoveRequested;

        public int Health => _health;

        [SerializeField] private Transform _firePoint;
        [SerializeField] private int _health = 3;
        [SerializeField] private float _speed = 5.0f;
        [SerializeField] private BulletController _bulletController;

        private Rigidbody2D _rigidbody;

        private void OnEnable()
        {
            OnAttackRequested += Attack;
            OnMoveRequested += Move;
        }

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void RequestAttack()
        {
            OnAttackRequested?.Invoke();
        }

        public void RequestMove(float direction)
        {
            OnMoveRequested?.Invoke(direction);
        }

        private void Move(float direction)
        {
            var moveDirection = new Vector2(direction, 0);
            var moveStep = moveDirection * Time.fixedDeltaTime * _speed;
            var targetPosition = _rigidbody.position + moveStep;
            _rigidbody.MovePosition(targetPosition);
        }       

        private void Attack()
        {
            _bulletController.SpawnBullet(_firePoint.position, Color.blue, (int)PhysicsLayer.PLAYER_BULLET, 1, true, _firePoint.rotation * Vector3.up * 3);
        }

        public void TakeDamage(int amount)
        {
            _health = Mathf.Max(0, Health - amount);
            if (Health <= 0)
                Time.timeScale = 0;
        }

        private void OnDisable()
        {
            OnAttackRequested -= Attack;
            OnMoveRequested -= Move;
        }       
    }
}