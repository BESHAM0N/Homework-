using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class DamageAnimBehaviour: IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private IEvent<int> _damageEvent;
        private static readonly int Hit = Animator.StringToHash("TakeDamage");

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _damageEvent = entity.GetDamageEvent();
            _damageEvent.Subscribe(OnDamageReceived);
        }

        public void Dispose(in IEntity entity)
        {
            _damageEvent.Unsubscribe(OnDamageReceived);
        }

        private void OnDamageReceived(int damage)
        {
            _animator.SetTrigger(Hit);
        }
    }
}