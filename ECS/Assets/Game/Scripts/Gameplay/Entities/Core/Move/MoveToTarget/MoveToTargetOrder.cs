using Leopotam.EcsLite;

namespace ECSGame
{
    public struct MoveToTargetOrder
    {
        public EcsPackedEntity target;
        public float stopDistance;
    }
}