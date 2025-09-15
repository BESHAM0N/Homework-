using System;
using Leopotam.EcsLite;

namespace ECSGame
{
    [Serializable]
    public struct FireEvent
    {
        public EcsPackedEntity entity;
    }
}