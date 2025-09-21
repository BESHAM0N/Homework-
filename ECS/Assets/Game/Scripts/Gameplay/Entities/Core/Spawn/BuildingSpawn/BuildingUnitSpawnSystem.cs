using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public sealed class BuildingUnitSpawnSystem : IEcsRunSystem
    {
        private readonly UnitsTeamConfig _config;

        private readonly EcsEventInject<BuildingSpawnEvent> _events;
        private readonly EcsEventInject<UnitSpawnRequest> _spawnRequests;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUse;

        public BuildingUnitSpawnSystem(UnitsTeamConfig config)
        {
            _config = config;
        }

        public void Run(IEcsSystems _)
        {
            while (_events.Value.Consume(out BuildingSpawnEvent e))
            {
                TeamType team = _teamUse.Value.GetTeam(e.buildingEntity);
                var prototype = _config.GetPrototype(team, e.unitType);

                _spawnRequests.Value.Fire(new UnitSpawnRequest
                {
                    prefab = prototype,
                    position = e.position,
                    rotation = e.rotation,
                    team = team
                });
            }
        }
    }
}