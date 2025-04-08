using UnityEngine;

namespace Component
{
    public class Snake : MonoBehaviour
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private DropOffComponent _dropOffComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private RotateComponent _rotateComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private SoundComponent _soundComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _dropOffComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void OnEnable()
        {
            _attackComponent.OnAttacked += OnDrop;
            _lifeComponent.OnEmpty += OnHealthEmpty;
            _lifeComponent.OnHit += OnTakeDamage;
            _moveComponent.OnRotate += _rotateComponent.SetDirection;
        }

        private void OnDisable()
        {
            _attackComponent.OnAttacked -= OnDrop;
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _lifeComponent.OnHit -= OnTakeDamage;
            _moveComponent.OnRotate -= _rotateComponent.SetDirection;
        }

        private void OnDrop()
        {
            _dropOffComponent.ExecuteDropOff();
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