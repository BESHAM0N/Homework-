using UnityEngine;

namespace Component
{
    public sealed class Spider : MonoBehaviour
    {
        [SerializeField] private RepulsionComponent _repulsionComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private int _damage = 3;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _repulsionComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += OnHealthEmpty;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
        }
        
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable proxy))
            {
                proxy.TakeDamage(_damage);
                _repulsionComponent.ExecuteAction(Vector2.zero);
            }
        }
        
        private void OnHealthEmpty()
        {
            _deathComponent.Death();
        }
    }
}