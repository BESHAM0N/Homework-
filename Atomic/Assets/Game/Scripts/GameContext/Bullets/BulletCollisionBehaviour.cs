using System;
using Atomic.Elements;
using Atomic.Entities;
using Game.Gameplay;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Behavior
{
    public class BulletCollisionBehaviour : IEntityInit, IEntityDispose
    {
        private IAction _destroyAction;
        private TriggerEventReceiver _trigger;
        private IValue<int> _damage;

        public void Init(in IEntity entity)
        {
            _destroyAction = entity.GetDestroyAction();
            _damage = entity.GetDamage();
            _trigger = entity.GetTrigger();

            _trigger.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            if (collider.TryGetComponent(out IEntity target) && HealthUseCase.TakeDamage(target, _damage.Value))
                _destroyAction.Invoke();
        }
    }
}