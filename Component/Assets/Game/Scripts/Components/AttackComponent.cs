using System;
using UnityEngine;

namespace Component
{
    public class AttackComponent : MonoBehaviour
    {
        public event Action OnAttacked;
        
        [SerializeField] private int _damage;
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable proxy))
            {
                OnAttacked?.Invoke();
                proxy.TakeDamage(_damage);
            }
        }

        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     Debug.Log($"А такую: {gameObject.name}");
        //     if (other.TryGetComponent(out IDamageable proxy))
        //     {
        //         proxy.TakeDamage(_damage);
        //         OnAttacked?.Invoke();
        //     }
        // }
    }
}