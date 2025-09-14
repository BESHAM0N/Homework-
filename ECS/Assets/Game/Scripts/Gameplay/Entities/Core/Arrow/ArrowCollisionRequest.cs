using System;
using Leopotam.EcsLite;

namespace ECSGame
{
    [Serializable]
    public struct ArrowCollisionRequest
    {
        public EcsPackedEntity arrow;
        public EcsPackedEntity target;
    }
}