using Leopotam.EcsLite;

namespace ECSGame
{
    public struct MoveToTargetRequest
    {
        public int unitEntity;
        public EcsPackedEntity target;
        public float stopDistance;
    }
}