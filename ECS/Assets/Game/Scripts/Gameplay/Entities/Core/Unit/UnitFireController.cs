using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace ECSGame
{
    public class UnitFireController : IEcsInitSystem, IEcsRunSystem
    {
        //Должны быть данными по ссылке, не объекты.
        //private readonly EcsSingletonInject<>
        
        private readonly EcsFilterInject<Inc<UnitFireRequired>> _units;
        private readonly EcsPoolInject<TeamType> _teamTypes;

        public void Init(IEcsSystems systems)
        {
            //systems.GetWorld().GetSingleton<>();
        }
        
        public void Run(IEcsSystems systems)
        {
            bool isFire = false;
            foreach (var unit in _units.Value)
            {
                //TODO: Логика атаки для юнитов
                ref TeamType teamType = ref _teamTypes.Value.Get(unit);
                ref UnitFireRequired required = ref _units.Pools.Inc1.Get(unit);
                required.value = isFire;
            }
        }
    }
}