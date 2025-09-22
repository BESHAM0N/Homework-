using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class BuildingUnitSpawnSystem : IEcsRunSystem
    {
        private readonly EcsPrototypeCatalog _prototypes;
        private readonly TeamViewConfig _teamView;

        public BuildingUnitSpawnSystem(EcsPrototypeCatalog prototypes, TeamViewConfig teamView)
        {
            _prototypes = prototypes;
            _teamView = teamView;
        }

        private readonly EcsEventInject<BuildingSpawnEvent> _clicks;
        private readonly EcsEventInject<UnitSpawnRequest> _spawns;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUse;

        public void Run(IEcsSystems _)
        {
            while (_clicks.Value.Consume(out BuildingSpawnEvent buildingSpawnEvent))
            {
                TeamType team = _teamUse.Value.GetTeam(buildingSpawnEvent.buildingEntity);
                var prototype = _prototypes.GetPrototype(buildingSpawnEvent.unitType.ToString());
                var viewKey = TeamViewUseCase.GetViewKey(_teamView, team, buildingSpawnEvent.unitType);
                
                _spawns.Value.Fire(new UnitSpawnRequest
                {
                    prefab = prototype,
                    position = buildingSpawnEvent.position,
                    rotation = buildingSpawnEvent.rotation,
                    team = team,
                    viewKey  = viewKey
                });
            }
        }
    }
}