using ECSGame;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

public sealed class DeathSystem : IEcsRunSystem
{
    private readonly EcsFilterInject<Inc<DeathableTag>> _deathables;
    private readonly EcsPoolInject<Health> _healths;
    private readonly EcsEventInject<DestroyRequest> _destroyRequest;
    
    public void Run(IEcsSystems systems)
    {
        foreach (var entity in _deathables.Value)
        {
            var health = _healths.Value.Get(entity);
            if(health.current == 0)
                _destroyRequest.Value.Fire(new DestroyRequest{entity = entity});
        }    
    }
}
