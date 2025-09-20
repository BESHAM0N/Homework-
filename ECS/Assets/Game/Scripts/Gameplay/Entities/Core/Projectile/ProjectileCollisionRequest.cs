using System;
using Leopotam.EcsLite;

namespace ECSGame
{
    [Serializable]
    public struct ProjectileCollisionRequest
    {
        public EcsPackedEntity projectile;
        public EcsPackedEntity target;
    }
}