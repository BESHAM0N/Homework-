using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame.Common.Interact
{
    public sealed class InteractBehaviour : IEntityInit, IEntityDispose
    {
        private TriggerEventReceiver _trigger;
        private IEntity _entity;
        
        public void Init(in IEntity entity)
        {
            _entity = entity;
            _trigger = entity.GetTrigger();
            _trigger.OnEntered += this.OnTriggerEntered;
        }

        public void Dispose(in IEntity entity)
        {
            _trigger.OnEntered -= this.OnTriggerEntered;
        }

        private void OnTriggerEntered(Collider collider)
        {
            InteractUseCase.Interact(_entity, collider);
        }
    }
}