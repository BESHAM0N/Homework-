using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;

namespace ECSGame
{
    public class EcsAdmin : MonoBehaviour
    {
        public static IEcsSystems Systems { get; private set; }

        [SerializeField] private EcsSystemsFactory _systemsFactory;

        [SerializeField] private EcsBaker _baker;

        [SerializeField] private EcsWorldView _worldView;
        
        [SerializeField] private TeamViewConfig _teamViewConfig;

        private void Awake()
        {
            IEcsSystems systems = _systemsFactory.Create();
            _baker.BakeScene(systems.GetWorld());
            FixViewKeysForBases(systems.GetWorld());

            systems
                .Inject()
                .Init();

            Systems = systems;
        }

        private void Start()
        {
            _worldView.Show(Systems.GetWorld());
        }

        private void Update()
        {
            Systems?.Run();
        }

        private void OnDestroy()
        {
            Systems.GetWorld().Destroy();
            Systems.Destroy();
        }
        
        private void FixViewKeysForBases(EcsWorld world)
        {
            var names    = world.GetPool<EcsName>();
            var teams    = world.GetPool<TeamType>();
            var buildings= world.GetPool<BuildingTag>(); // метка базы

            int[] entities = null;
            int count = world.GetAllEntities(ref entities);

            for (int i = 0; i < count; i++)
            {
                int e = entities[i];
                if (!names.Has(e) || !teams.Has(e) || !buildings.Has(e)) continue;

                var team = teams.Get(e);
                // Переводим короткое имя "Base" в каталогное "Base (Blue/Red)"
                names.Get(e).value = TeamViewUseCase.GetViewKey(_teamViewConfig, team, UnitType.Building);
            }
        }
    }
}