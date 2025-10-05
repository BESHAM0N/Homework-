using ECSGame;
using UnityEngine;

namespace Leopotam.EcsLite
{
    public class EcsBaker : MonoBehaviour
    {
        [SerializeField] private EcsPrototypeCatalog _prototypes;
        [SerializeField] private TeamViewConfig _teamViewConfig;

        public void BakeScene(EcsWorld world, bool includeInactive = false)
        {
            var views = FindObjectsOfType<EcsView>(includeInactive);

            for (int i = 0, count = views.Length; i < count; i++)
            {
                var view = views[i];
                BakeEntity(world, view);
            }
        }

        public void BakeEntity(in EcsWorld world, in EcsView view)
        {
            var prototypeName = TeamViewUseCase.ResolvePrototypeNameByViewName(_teamViewConfig, view.Name);
            var prefab = _prototypes.GetPrototype(prototypeName);
            var entity = prefab.Create(world);

            var converters = view.GetComponentsInChildren<IEcsEntityInstaller>();
            for (int i = 0, count = converters.Length; i < count; i++)
            {
                var converter = converters[i];
                converter.Install(world, entity);
            }

            var names = world.GetPool<EcsName>();
            ref var reference = ref (names.Has(entity) ? ref names.Get(entity) : ref names.Add(entity));
            reference.value = view.Name;

            var teamPool = world.GetPool<TeamType>();
            if (string.IsNullOrEmpty(reference.value) || reference.value == prototypeName)
            {
                var team = teamPool.Has(entity) ? teamPool.Get(entity) : TeamType.BLUE;
                var unitType = prototypeName
                    switch
                    {
                        "Base" => UnitType.Building,
                        "Archer" => UnitType.Archer,
                        "Swordman" => UnitType.Swordman,
                        "Arrow" => UnitType.Arrow
                    };
                reference.value = TeamViewUseCase.GetViewKey(_teamViewConfig, team, unitType);
            }

            Destroy(view.gameObject);
        }
    }
}