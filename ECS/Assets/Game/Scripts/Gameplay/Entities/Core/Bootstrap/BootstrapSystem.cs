using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public sealed class BootstrapSystem : IEcsInitSystem
    {
        private readonly EcsCustomInject<EcsPrototypeCatalog> _prototypes;
        
        private readonly EcsUseCaseInject<BootstrapUseCase> _buildingSpawn;
        
        private static readonly float3 BluePos = new (-8f, 0f, 0f);
        private static readonly float3 RedPos  = new ( 38f, 0f, 0f);
        
        private static readonly quaternion BlueRot = quaternion.RotateY(math.radians(-90f));
        private static readonly quaternion RedRot  = quaternion.RotateY(math.radians( 90f));

        public void Init(IEcsSystems systems)
        {
            var baseProto = _prototypes.Value.GetPrototype("Base");

            _buildingSpawn.Value.SpawnBase(baseProto, BluePos, BlueRot, TeamType.BLUE);
            _buildingSpawn.Value.SpawnBase(baseProto, RedPos,  RedRot,  TeamType.RED);
        }
    }
}
