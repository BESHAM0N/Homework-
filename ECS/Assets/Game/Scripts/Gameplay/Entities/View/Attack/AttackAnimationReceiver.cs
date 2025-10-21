using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame.Entities.View.Attack
{
    public sealed class AttackAnimationReceiver : MonoBehaviour
    {
        [SerializeField] private EcsView _owner;
        [SerializeField] private MeleeHitView _meleeHitView;

        public void OnAttackAnimation()
        {
            _meleeHitView.EnableHitbox();
            Invoke(nameof(DisableHitbox), 0.15f);
        }

        private void DisableHitbox() => _meleeHitView.DisableHitbox();
    }
}