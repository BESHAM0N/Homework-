using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;       
        public int Damage { get; private set; }

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;

        public void Initialize(Color color, int physicsLayer, int damage, Vector2 velocity)
        {
            _spriteRenderer.color = color;
            gameObject.layer = physicsLayer;
            Damage = damage;           
            _rigidbody2D.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            OnCollisionEntered?.Invoke(this, collision);
        }

        public void HandleCollision(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(Damage);
            }
        }
    }
}