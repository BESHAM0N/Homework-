using System;
using UnityEngine;

namespace ShootEmUp
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet, Collision2D> OnCollisionEntered;

        public Vector2 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        [SerializeField] private Rigidbody2D _rigidbody2D;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        private int _damage;        

        public void Spawn(Vector2 position, Color color, int physicsLayer, int damage, Vector2 velocity, Transform parent)
        {
            transform.parent = parent;
            Position = position;
            
            _spriteRenderer.color = color;
            gameObject.layer = physicsLayer;
            _damage = damage;
            _rigidbody2D.velocity = velocity;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
                damageable.TakeDamage(_damage);

            OnCollisionEntered?.Invoke(this, collision);
        }
    }
}