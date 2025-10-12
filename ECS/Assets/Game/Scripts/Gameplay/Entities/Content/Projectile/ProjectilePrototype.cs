using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "ProjectilePrototype", menuName = "ECSGame/Entities/New Projectile")]
    public sealed class ProjectilePrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3;
        [SerializeField] private float _lifetime = 15;
        [SerializeField] private int _damage = 1;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<ProjectileTag>().Add(entity);
            
            //Move
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity);
            
            //lifetime
            world.GetPool<Lifetime>().Add(entity).value = _lifetime;
            
            //Damage
            world.GetPool<Damage>().Add(entity).value = _damage;
        }
    }
}