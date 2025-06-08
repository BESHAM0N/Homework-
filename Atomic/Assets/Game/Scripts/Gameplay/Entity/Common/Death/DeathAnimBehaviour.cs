using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class DeathAnimBehaviour : IEntityInit, IEntityDispose
    {
        private Animator _animator;
        private IReactiveValue<int> _health;
        private static readonly int Death = Animator.StringToHash("Death");

        public void Init(in IEntity entity)
        {
            _animator = entity.GetAnimator();
            _health = entity.GetHealth();
            _health.Subscribe(OnHealthChanged);
        }

        public void Dispose(in IEntity entity)
        {
            _health.Unsubscribe(OnHealthChanged);
        }

        private void OnHealthChanged(int value)
        {
            if (value <= 0)
                _animator.SetTrigger(Death);
        }
    }
}