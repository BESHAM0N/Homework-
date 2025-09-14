using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "ArrowPrototype", menuName = "ECSGame/Entities/New Arrow")]
    public sealed class ArrowPrototype : EcsPrototype
    {
        [SerializeField] private float _moveSpeed = 3;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            //Move
            world.GetPool<MoveableTag>().Add(entity);
            world.GetPool<MoveSpeed>().Add(entity).value = _moveSpeed;
            world.GetPool<MoveDirection>().Add(entity);
        }
    }
}