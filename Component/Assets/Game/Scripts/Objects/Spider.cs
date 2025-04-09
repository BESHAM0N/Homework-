using UnityEngine;

namespace Component
{
    public sealed class Spider : MonoBehaviour
    {
        [SerializeField] private AttackComponent _attackComponent;
        [SerializeField] private PushComponent _pushComponent;
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private MoveComponent _moveComponent;
        [SerializeField] private DeathComponent _deathComponent;

        private void Awake()
        {
            _moveComponent.AddCondition(_lifeComponent.IsAlive);
            _pushComponent.AddCondition(_lifeComponent.IsAlive);
        }

        private void OnEnable()
        {
            _attackComponent.OnAttacked += OnPush;
            _lifeComponent.OnEmpty += OnHealthEmpty;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= OnHealthEmpty;
            _attackComponent.OnAttacked -= OnPush;
        }

        private void OnPush()
        {
            _pushComponent.ExecutePush();
        }
        
        private void OnHealthEmpty()
        {
            _deathComponent.Death();
        }
    }
}