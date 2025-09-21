using Unity.Mathematics;

namespace ECSGame
{
    public struct BuildingSpawnEvent
    {
        public int buildingEntity;
        public UnitType unitType;
        public float3 position;
        public quaternion rotation;
    }
}