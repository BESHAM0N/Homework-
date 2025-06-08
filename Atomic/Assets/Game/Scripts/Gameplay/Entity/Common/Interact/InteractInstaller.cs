using System;
using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using UnityEngine;

namespace SampleGame.Common.Interact
{
    [Serializable]
    public sealed class InteractInstaller : IEntityInstaller
    {
        [SerializeField]
        private Transform _center;
        
        [SerializeField]
        private float _radius;

        [SerializeField]
        private LayerMask _layerMask;

        [SerializeField]
        private QueryTriggerInteraction _triggerInteraction;

        [SerializeField]
        private float _period = 0.1f;
        
        public void Install(IEntity entity)
        {
            //entity.AddTargetInteractible(new ReactiveVariable<IEntity>());
            entity.AddBehaviour(new DetectInteractibleBehaviour(_center, _radius, _layerMask, _triggerInteraction,
                new Cooldown(_period)));
        }
    }
}