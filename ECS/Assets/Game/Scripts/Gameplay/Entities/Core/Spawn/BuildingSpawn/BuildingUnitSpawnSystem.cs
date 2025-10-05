using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

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

        private readonly EcsEventInject<BuildingSpawnEvent> _events;
        private readonly EcsEventInject<UnitSpawnRequest> _spawns;
        private readonly EcsUseCaseInject<BaseQueryUseCase> _baseQuery;
        private readonly EcsUseCaseInject<SpawnTransformUseCase> _spawnTrs;
        private readonly EcsUseCaseInject<TeamUseCase> _teamUse;

        public void Run(IEcsSystems _)
        {
            while (_events.Value.Consume(out var buildingSpawnEvent))
            {
                int baseEntity = buildingSpawnEvent.buildingEntity;
                if (baseEntity < 0)
                {
                    baseEntity = _baseQuery.Value.FindBase(buildingSpawnEvent.team);
                    if (baseEntity == -1)
                    {
                        Debug.LogWarning(
                            $"[BuildingUnitSpawnSystem] Base not found for team {buildingSpawnEvent.team}");
                        continue;
                    }
                }

                var team = _teamUse.Value.GetTeam(baseEntity);
                var (position, rotation) = _spawnTrs.Value.GetNext(baseEntity);

                var prototype = _prototypes.GetPrototype(buildingSpawnEvent.unitType.ToString());
                var viewKey = TeamViewUseCase.GetViewKey(_teamView, team, buildingSpawnEvent.unitType);

                _spawns.Value.Fire(new UnitSpawnRequest
                {
                    prefab = prototype,
                    position = position,
                    rotation = rotation,
                    team = team,
                    viewKey = viewKey
                });
            }
        }
    }
}