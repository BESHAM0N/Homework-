using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public readonly struct BaseQueryUseCase
    {
        private readonly EcsWorldInject _world;
        private readonly EcsPoolInject<BuildingTag> _buildings;
        private readonly EcsPoolInject<TeamType> _teams;

        public int FindBase(TeamType team)
        {
            int[] ents = null;
            int count = _world.Value.GetAllEntities(ref ents);

            for (int i = 0; i < count; i++)
            {
                int teamType = ents[i];
                if (!_buildings.Value.Has(teamType)) continue;
                if (!_teams.Value.Has(teamType)) continue;

                if (_teams.Value.Get(teamType).Equals(team))
                {
                    return teamType;
                }
            }

            return -1;
        }
    }
}