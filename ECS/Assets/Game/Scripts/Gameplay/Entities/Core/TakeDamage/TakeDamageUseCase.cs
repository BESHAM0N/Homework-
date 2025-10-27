using ECSGame;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace Client.Entities.Core.TakeDamage
{
    //структура, чтобы мы могли вернуть результат. Является вспомогательным методом для системы. 
    public readonly struct TakeDamageUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<Damage> _damages;
        private readonly EcsUseCaseInject<HealthUseCase> _healthUseCase;
        private readonly EcsEventInject<TakeDamageEvent> _takeDamageEvents;

        public bool TakeDamage(EcsPackedEntity source, EcsPackedEntity target)
        {
            if (!source.Unpack(_world.Value, out int sourceId) || !target.Unpack(_world.Value, out int targetId))
            {
                return false;
            }

            ref int damage = ref _damages.Value.Get(sourceId).value;

            if (_healthUseCase.Value.Reduce(targetId, damage))
            {
                _world.Value.GetEvent<DamageFxEvent>().Fire(new DamageFxEvent
                {
                    entity = target,
                    isDestroyed = !_healthUseCase.Value.Exists(targetId)
                });
            }
            
            _takeDamageEvents.Value.Fire(new TakeDamageEvent
            {
                source = source,
                target = target,
                damage = damage
            });
            
            return true;
        }
    }
}