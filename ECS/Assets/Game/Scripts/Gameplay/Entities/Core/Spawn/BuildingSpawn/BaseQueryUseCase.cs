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
                int e = ents[i];
                if (_buildings.Value.Has(e) && _teams.Value.Has(e) && _teams.Value.Get(e) == team)
                    return e;
            }
            return -1;
        }

        public bool TryFindBase(TeamType team, out int entity)
        {
            entity = FindBase(team);
            return entity != -1;
        }
    }
}