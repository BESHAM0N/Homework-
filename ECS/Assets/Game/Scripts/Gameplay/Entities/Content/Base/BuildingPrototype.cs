using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Base", menuName = "ECSGame/Entities/New Base")]
    public sealed class BuildingPrototype : EcsPrototype
    {
        [SerializeField] private int _health = 50;
        
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BuildingTag>().Add(entity);
            world.GetPool<DeathableTag>().Add(entity);
            
            //Health
            world.GetPool<Health>().Add(entity) = new Health
            {
                current = _health,
                max = _health
            };
        }
    }
}