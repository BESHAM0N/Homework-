using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Archer", menuName = "ECSGame/Entities/New Archer")]
    public sealed class ArcherPrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 0.3f;
        [SerializeField] private float3 _fireOffset = new float3(0, 1, 1);
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<ArcherTag>().Add(entity);
            
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
            world.GetPool<FireOffset>().Add(entity).value = _fireOffset;
        }
    }
}