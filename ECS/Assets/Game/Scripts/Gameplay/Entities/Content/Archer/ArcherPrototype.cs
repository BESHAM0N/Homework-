using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Archer", menuName = "ECSGame/Entities/New Archer")]
    public sealed class ArcherPrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 10f;
        [SerializeField] private int _health = 20;
        [SerializeField] private float _fireCooldown = 4f;
        [SerializeField] private float _range = 11f;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<UnitTag>().Add(entity);
            world.GetPool<AttackableTag>().Add(entity);
            world.GetPool<DeathableTag>().Add(entity);
            world.GetPool<ArcherTag>().Add(entity);
            
            //Health
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };
            
            //Move
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity).value = new float3(0, 0, 1);
            
            //Rotate
            world.GetPool<RotatableTag>().Add(entity);
            world.GetPool<RotateSpeed>().Add(entity).value = _rotationSpeed;
            world.GetPool<RotateDirection>().Add(entity).value = new float3(0, 0, -1);
            
            //Fire
            world.GetPool<AttackRange>().Add(entity).value  = _range;
            world.GetPool<UnitFireRequired>().Add(entity);
            world.GetPool<FireOffset>().Add(entity).value = new float3(0f, 1.0f, 0.5f);
            world.GetPool<FireCooldown>().Add(entity) = new FireCooldown
            {
                current = 0,
                duration = _fireCooldown
            };
        }
    }
}