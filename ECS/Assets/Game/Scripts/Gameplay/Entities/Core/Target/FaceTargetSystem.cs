using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public sealed class FaceTargetSystem : IEcsRunSystem
    {
        private readonly EcsFilterInject<Inc<RotatableTag, Target, Position, RotateDirection>> _filter;
        private readonly EcsPoolInject<Target> _targets;
        private readonly EcsPoolInject<Position> _pos;
        private readonly EcsUseCaseInject<TargetUseCase> _targetUse;

        public void Run(IEcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var packed = ref _targets.Value.Get(entity).value;
                
                if (!_targetUse.Value.TryUnpack(packed, out var tgt)) 
                    continue;
                if (!_pos.Value.Has(tgt)) 
                    continue;

                var from = _pos.Value.Get(entity).value;
                var to = _pos.Value.Get(tgt).value;
                var dir = to - from;
                dir.y = 0;

                if (math.lengthsq(dir) < 1e-6f)
                    continue;
               
                _filter.Pools.Inc4.Get(entity).value =  math.normalize(dir);
            }
        }
    }
}