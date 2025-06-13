using Atomic.Elements;
using Atomic.Entities;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class DetectInteractibleBehaviour : IEntityInit, IEntityFixedUpdate, IEntityGizmos
    {
        private IReactiveVariable<IEntity> _target;

        private readonly Transform _center;
        private readonly float _radius;
        private readonly LayerMask _layerMask;
        private readonly QueryTriggerInteraction _triggerInteraction;
        private readonly Cooldown _period;

        public DetectInteractibleBehaviour(
            Transform center,
            float radius,
            LayerMask layerMask,
            QueryTriggerInteraction triggerInteraction,
            Cooldown period
        )
        {
            _center = center;
            _radius = radius;
            _layerMask = layerMask;
            _triggerInteraction = triggerInteraction;
            _period = period;
        }

        public void Init(in IEntity entity)
        {
            _target = entity.GetTargetInteractible();
        }

        public void OnFixedUpdate(in IEntity entity, in float deltaTime)
        {
            _period.Tick(deltaTime);
            if (!_period.IsExpired())
                return;

            InteractUseCase.FindClosest(_center.position, _radius, _layerMask, _triggerInteraction, out IEntity target);
            _target.Value = target;
            _period.Reset();
        }

        public void OnGizmosDraw(in IEntity entity)
        {
            Gizmos.DrawWireSphere(_center.position, _radius);
        }
    }
}