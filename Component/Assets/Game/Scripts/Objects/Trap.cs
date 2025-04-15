using UnityEngine;

namespace Component
{
    public sealed class Trap :MonoBehaviour
    {
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private int _damage = 5;
        
        private void OnEnable()
        {
            _lifeComponent.OnEmpty += _deathComponent.Death;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= _deathComponent.Death;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable proxy))
            {
                proxy.TakeDamage(_damage);
                _deathComponent.Death();
            }
        }
    }
}