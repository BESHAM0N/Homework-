using System;
using Leopotam.EcsLite;
using Unity.Mathematics;

namespace ECSGame
{
    [Serializable]
    public struct ProjectileSpawnRequest
    {
        public EcsPrototype prefab;
        public float3 position;
        public quaternion rotation;
        public TeamType team;
    }
}