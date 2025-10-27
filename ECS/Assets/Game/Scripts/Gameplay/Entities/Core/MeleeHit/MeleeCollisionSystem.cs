using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class MeleeCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<MeleeHitRequest> _hitRequests;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamageUseCase;
        private readonly EcsPoolInject<TeamType> _teams;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var req in _hitRequests.Value)
            {
                if (!req.attacker.Unpack(_world.Value, out int attacker) ||
                    !req.target.Unpack(_world.Value, out int target))
                    continue;
              
                if (_teams.Value.Has(attacker) && _teams.Value.Has(target))
                {
                    if (_teams.Value.Get(attacker) == _teams.Value.Get(target))
                        continue;
                }
                
                if (attacker == target) 
                    continue;
            
                _takeDamageUseCase.Value.TakeDamage(req.attacker, req.target);
            }
        }
    }
}