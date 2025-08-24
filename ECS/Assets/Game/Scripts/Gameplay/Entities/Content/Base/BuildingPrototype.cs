using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    [CreateAssetMenu(fileName = "Base", menuName = "ECSGame/Entites/New Base")]
    public sealed class BuildingPrototype : EcsPrototype
    {
        protected override void Install(in EcsWorld world, in int entity)
        {
            world.GetPool<BuildingTag>().Add(entity);
        }
    }
}