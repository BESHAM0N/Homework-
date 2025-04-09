using UnityEngine;

namespace Component
{
    public sealed class Lava : MonoBehaviour
    {
        [SerializeField] private SoundComponent _soundComponent;
        [SerializeField] private AttackComponent _attackComponent;

        private void OnEnable()
        {
            _attackComponent.OnAttacked += OnAttack;
        }

        private void OnDisable()
        {
            _attackComponent.OnAttacked -= OnAttack;
        }

        private void OnAttack()
        {
            _soundComponent.PlaySound(SoundType.Lava);
        }
    }
}