using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class MoveOrderSystem : IEcsRunSystem
    {
        private readonly EcsEventInject<MoveToTargetRequest> _requests;
        private readonly EcsPoolInject<MoveToTargetOrder> _orders;

        public void Run(IEcsSystems _)
        {
            while (_requests.Value.Consume(out MoveToTargetRequest request))
            {
                if (_orders.Value.Has(request.unitEntity))
                {
                    ref var targetOrder = ref _orders.Value.Get(request.unitEntity);
                    targetOrder.target = request.target;
                    targetOrder.stopDistance = request.stopDistance;
                }
                else
                {
                    _orders.Value.Add(request.unitEntity) = new MoveToTargetOrder
                    {
                        target = request.target,
                        stopDistance = request.stopDistance
                    };
                }
            }
        }
    }
}