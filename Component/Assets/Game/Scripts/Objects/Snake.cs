using UnityEngine;

namespace Component
{
    public sealed class Snake : MonoBehaviour
    {
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotateComponent _rotateComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private SoundComponent _soundComponent;
        [SerializeField] private RepulsionComponent _repulsionComponent;
        [SerializeField] private int _damage = 5;
        
        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _repulsionComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void OnEnable()
        {
            _lifeComponent.OnEmpty += OnHealthEmpty;
            _lifeComponent.OnHit += OnTakeDamage;
            _moveComponent.OnRotate += _rotateComponent.SetDirection;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _lifeComponent.OnHit -= OnTakeDamage;
            _moveComponent.OnRotate -= _rotateComponent.SetDirection;
        }
       
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable proxy))
            {
                proxy.TakeDamage(_damage);
                _repulsionComponent.ExecuteAction(Vector2.up);
            }
        }

        private void OnHealthEmpty()
        {
            _deathComponent.Death();
        }

        private void OnTakeDamage()
        {
           _soundComponent.PlaySound(SoundType.TakeDamageEnemy);
        }
    }
}