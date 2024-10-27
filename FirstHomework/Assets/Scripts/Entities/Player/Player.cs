using UnityEngine;

namespace ShootEmUp
{
    public sealed class Player : Ship
    {
        [SerializeField] private BulletManager _bulletManager;
        
        private readonly Color _bulletColor = Color.blue;
        private readonly int _valueVelocity = 3;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float direction)
        {
            var moveDirection = new Vector2(direction, 0);
            var moveStep = moveDirection * Time.fixedDeltaTime * _speed;
            var targetPosition = _rigidbody.position + moveStep;
            _rigidbody.MovePosition(targetPosition);
        }

        public void Attack()
        {
            _bulletManager.SpawnBullet(_firePoint.position, _bulletColor, (int)PhysicsLayer.PLAYER_BULLET, _damage,
                _firePoint.rotation * Vector3.up * _valueVelocity);
        }
    }
}