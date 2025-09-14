using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Swordman", menuName = "ECSGame/Entities/New Swordman")]
    public  sealed class SwordmanPrototype : EcsPrototype
    { 
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 0.3f;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<SwordmanTag>().Add(entity);
            
            //Move
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity).value = new float3(0, 0, 1);
            
            //Rotate
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateSpeed>().Add(entity).value = _rotationSpeed;
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0, 0, -1);
            
            //Fire
            world.GetPool<UnitFireRequired>().Add(entity);
        }
    }
}