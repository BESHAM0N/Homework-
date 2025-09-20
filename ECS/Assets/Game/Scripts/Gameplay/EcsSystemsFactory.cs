using Client.Entities.Core.TakeDamage;
using Leopotam.EcsLite;
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
        //[SerializeField]
        //private TeamViewConfig _teamViewConfig;
        [SerializeField] private TeamViewConfig _teamViewConfig;
        [SerializeField] private EcsPrototype _arrowPrefab;

        public IEcsSystems Create()
        {
            EcsWorld world = new EcsWorld();

            EcsSystems systems = new EcsSystems(world);

            systems

                //Game Logic
                .Add(new SpawnSystem())
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
                .Add(new TeamViewSystem(_teamViewConfig))
                .Add(new FireAnimSystem())
                .Add(new TakeDamageAnimSystem())
                .Add(new MoveAnimSystem())

                //Clear:
                .ClearEvents<FireEvent>()
                .ClearEvents<TakeDamageEvent>()

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            return systems;
        }
    }
}