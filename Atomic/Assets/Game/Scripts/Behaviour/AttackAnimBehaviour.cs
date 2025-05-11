using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class AttackAnimBehaviour : IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private IReactive _fireEvent;
        
        private static readonly int Fire = Animator.StringToHash("Attack");

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _fireEvent = entity.GetFireEvent();
            _fireEvent.Subscribe(OnFire);
        }

        public void Dispose(in IEntity entity)
        {
            _fireEvent.Unsubscribe(OnFire);
        }

        private void OnFire()
        {
            _animator.SetTrigger(Fire);
        }
    }
}