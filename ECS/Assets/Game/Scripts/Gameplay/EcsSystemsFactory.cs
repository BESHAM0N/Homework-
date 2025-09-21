using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
using Leopotam.EcsLite.ExtendedSystems;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECSGame
{
    [CreateAssetMenu(
        fileName = "EcsSystems",
        menuName = "ECSGame/New EcsSystems"
    )]
    public class EcsSystemsFactory : ScriptableObject
    {
        [SerializeField] private UnitsTeamConfig _unitsTeamConfig;
        [SerializeField] private EcsPrototype _arrowPrefab;

        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();

            EcsSystems systems = new EcsSystems(world);

            systems

                //Game Logic
                .Add(new UnitSpawnSystem())
                .Add(new TargetSystem())
                .Add(new MoveOrderSystem())
                .Add(new MoveToTargetSystem())
                .Add(new ArcherFireSystem(_arrowPrefab))
                .Add(new SwordmanMeleeSystem())
                .Add(new FireCooldownSystem())
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                .Add(new ProjectileCollisionSystem())
                .Add(new LifetimeSystem())
                .Add(new DeathSystem())
                .Add(new DestroySystem())

                //Rendering:
                .Add(new TransformViewSystem())
                .Add(new FireAnimSystem())
                .Add(new TakeDamageAnimSystem())
                .Add(new MoveAnimSystem())
                .Add(new BuildingUnitSpawnSystem(_unitsTeamConfig))

                //Clear:
                .ClearEvents<FireEvent>()
                .ClearEvents<TakeDamageEvent>()
                .ClearEvents<BuildingSpawnEvent>()

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            return systems;
        }
    }
}