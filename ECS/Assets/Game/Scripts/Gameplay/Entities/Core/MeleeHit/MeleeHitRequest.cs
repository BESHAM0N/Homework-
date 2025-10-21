using System;
using Leopotam.EcsLite;

namespace ECSGame
{
    [Serializable]
    public struct MeleeHitRequest
    {
        public EcsPackedEntity attacker;
        public EcsPackedEntity target;
    }
}