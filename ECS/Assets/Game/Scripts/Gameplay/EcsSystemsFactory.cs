using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(
        fileName = "EcsSystems",
        menuName = "ECSGame/New EcsSystems"
    )]
    public class EcsSystemsFactory : ScriptableObject
    {
        [SerializeField] private EcsPrototypeCatalog _prototypeCatalog;
        [SerializeField] private TeamViewConfig _teamViewConfig;
        [SerializeField] private EcsPrototype _arrowPrefab;

        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();

            EcsSystems systems = new EcsSystems(world);

            systems
                .Add(new BootstrapSystem())
                .Add(new BuildingUnitSpawnSystem())
                .Add(new UnitSpawnSystem())
                .Add(new ProjectileSpawnSystem())
                
                //Game Logic
                .Add(new TargetSystem())
                .Add(new MoveOrderSystem())
                .Add(new MoveToTargetSystem())
                .Add(new ArcherFireSystem(_arrowPrefab))
                .Add(new SwordmanMeleeSystem())
                .Add(new FireCooldownSystem())
                .Add(new MoveSystem())
                .Add(new FaceTargetSystem())
                .Add(new RotationSystem())
                .Add(new ProjectileCollisionSystem())
                .Add(new MeleeCollisionSystem())
                .Add(new LifetimeSystem())
                .Add(new DeathSystem())
                .Add(new DestroySystem())
                .Add(new DamageFxSystem())

                //Rendering:
                .Add(new TransformViewSystem())
                .Add(new MoveAnimSystem())
                .Add(new FireAnimSystem())
                .Add(new TakeDamageAnimSystem())

                //Clear:
                .ClearEvents<MeleeHitRequest>()
                .ClearEvents<ProjectileCollisionRequest>()
                .ClearEvents<FireEvent>()
                .ClearEvents<TakeDamageEvent>()
                .ClearEvents<BuildingSpawnEvent>()
                .ClearEvents<DamageFxEvent>()

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            return systems;
        }
    }
}