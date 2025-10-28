using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Unity.Mathematics;

namespace ECSGame
{
    public struct BootstrapUseCase
    {
        private readonly EcsUseCaseInject<UnitSpawnUseCase> _unitSpawn;
        private readonly EcsPoolInject<BuildingTag> _buildings;
        private readonly EcsPoolInject<EcsName> _names;
        private readonly EcsCustomInject<TeamViewConfig> _teamView;
      
        public int SpawnBase(EcsPrototype baseProto, in float3 pos, in quaternion rot, in TeamType team)
        {
            var entity = _unitSpawn.Value.UnitSpawn(baseProto, pos, rot, team);
            
            if (!_buildings.Value.Has(entity))
                _buildings.Value.Add(entity);
        
            var viewKey = TeamViewUseCase.GetViewKey(_teamView.Value, team, UnitType.Building);
            ref var name = ref (_names.Value.Has(entity) ? ref _names.Value.Get(entity) : ref _names.Value.Add(entity));
            name.value = viewKey;

            return entity;
        }
    }
}