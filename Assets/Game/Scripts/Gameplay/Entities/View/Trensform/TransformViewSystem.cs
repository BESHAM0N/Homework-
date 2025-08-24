using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class TransformViewSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<TransformView, Position, Rotation>> _entities;
        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _entities.Value)
            {
               ref var transform = ref _entities.Pools.Inc1.Get(entity);
               ref var position = ref _entities.Pools.Inc2.Get(entity);
               ref var rotation = ref _entities.Pools.Inc3.Get(entity);
               
               transform.value.SetLocalPositionAndRotation(position.value, rotation.value);
            }
        }
    }
}