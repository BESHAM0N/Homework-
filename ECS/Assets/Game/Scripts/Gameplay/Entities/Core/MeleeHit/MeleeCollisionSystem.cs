using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class MeleeCollisionSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<MeleeHitRequest> _hitRequests;
        private readonly EcsUseCaseInject<TakeDamageUseCase> _takeDamage;
        private readonly EcsPoolInject<TeamType> _teams;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var req in _hitRequests.Value)
            {
                if (!req.attacker.Unpack(_world.Value, out int a) ||
                    !req.target.Unpack(_world.Value, out int t))
                    continue;
              
                if (_teams.Value.Has(a) && _teams.Value.Has(t))
                {
                    if (_teams.Value.Get(a) == _teams.Value.Get(t))
                        continue;
                }
                
                if (a == t) continue;
            
                _takeDamage.Value.TakeDamage(req.attacker, req.target);
            }
        }
    }
}