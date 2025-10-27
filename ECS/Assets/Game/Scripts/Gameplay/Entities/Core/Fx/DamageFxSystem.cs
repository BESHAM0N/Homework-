using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class DamageFxSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<DamageFxEvent> _fxEvents;
        private readonly EcsPoolInject<DamageFxView> _fxPool;
        private readonly EcsWorldInject _world;

        public void Run(IEcsSystems systems)
        {
            foreach (var fxEvent in _fxEvents.Value)
            {
                if (!fxEvent.entity.Unpack(_world.Value, out int e))
                    continue;

                if (_fxPool.Value.Has(e))
                {
                    ref var fx = ref _fxPool.Value.Get(e);
                    fx.particle?.Play();

                    if (fxEvent.isDestroyed)
                        fx.fireEffect?.Play();
                }
            }
        }
    }
}