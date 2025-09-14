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

                //Controllers
                .Add(new UnitFireController())

                //Game Logic
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                .Add(new ArrowSpawnSystem())
                .Add(new ArrowCollisionSystem())
                .Add(new LifetimeSystem())
                .Add(new DeathSystem())
                .Add(new DestroySystem())

                .Add(new ArcherFireSystem(_arrowPrefab))

                //Rendering:
                .Add(new TransformViewSystem())
                .Add(new TeamViewSystem(_teamViewConfig))
                // .Add(new FireAnimSystem())
                //.Add(new TakeDamageAnimSystem())
                // .Add(new MoveAnimSystem())

                //Clear:
                .ClearEvents<FireEvent>()
                .ClearEvents<TakeDamageEvent>()
                // .Add(new ClearEventSystem<FireEvent>(world))

                //Debug:
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem());
#endif
            return systems;
        }
    }
}