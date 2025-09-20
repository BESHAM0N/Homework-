using Leopotam.EcsLite;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Swordman", menuName = "ECSGame/Entities/New Swordman")]
    public sealed class SwordmanPrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _rotationSpeed = 0.3f;
        [SerializeField] private int _health = 5;
        [SerializeField] private float _fireCooldown = 0.4f;

        [SerializeField] private float _range = 5f;
        [SerializeField] private int _damage = 2;

        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<UnitTag>().Add(entity);
            world.GetPool<AttackableTag>().Add(entity);
            world.GetPool<DeathableTag>().Add(entity);
            world.GetPool<SwordmanTag>().Add(entity);

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
            world.GetPool<UnitFireRequired>().Add(entity);
            world.GetPool<FireCooldown>().Add(entity) = new FireCooldown
            {
                current = 0,
                duration = _fireCooldown
            };
            
            // Melee
            world.GetPool<Damage>().Add(entity).value = _damage;
            world.GetPool<AttackRange>().Add(entity).value  = _range;
        }
    }
}