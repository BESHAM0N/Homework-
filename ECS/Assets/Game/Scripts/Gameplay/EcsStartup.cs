using System;
using ECSGame;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using Sirenix.OdinInspector;
using Unity.Mathematics;
using UnityEngine;

namespace ECSGame 
{
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;        
        IEcsSystems _systems;
        
        [SerializeField] private EcsWorldView _worldView;
        private void Awake()
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            _systems
                //Game logic
                .Add(new MoveSystem())
                .Add(new RotationSystem())
                
                //Render
                .Add(new TransformViewSystem())
#if UNITY_EDITOR
                .Add (new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem ())
#endif
                .Inject() 
                .Init ();
        }

        private void Start()
        {
            _worldView.Show(_world);
        }

        [Button]
        private void CreateEntity(EcsPrototype prefab, float3 position, quaternion rotation)
        {
            var entity = prefab.Create(_world); //Создание новой сущности 
            
            _world.GetPool<Position>().Add(entity).value = position;
            _world.GetPool<Rotation>().Add(entity).value = rotation;
        }

        [Button]
        private void DeleteEntity(int indexEntity)
        {
            _world.DelEntity(indexEntity);
        }

        void Update () {
            // process systems here.
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                // list of custom worlds will be cleared
                // during IEcsSystems.Destroy(). so, you
                // need to save it here if you need.
                _systems.Destroy ();
                _systems = null;
            }
            
            // cleanup custom worlds here.
            
            // cleanup default world.
            if (_world != null) {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}