using UnityEngine;

namespace Component
{
    public sealed class Trap :MonoBehaviour
    {
        [SerializeField] private LifeComponent _lifeComponent;
        [SerializeField] private DeathComponent _deathComponent;
        [SerializeField] private AttackComponent _attackComponent;
        
        private void OnEnable()
        {
            _lifeComponent.OnEmpty += _deathComponent.Death;
            _attackComponent.OnAttacked += _deathComponent.Death;
        }

        private void OnDisable()
        {
            _lifeComponent.OnEmpty -= _deathComponent.Death;
            _attackComponent.OnAttacked -= _deathComponent.Death;
        }
    }
}