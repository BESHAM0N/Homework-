using Leopotam.EcsLite;
using UnityEngine;

namespace Leopotam.EcsLite
{
    public abstract class EcsPrototype : ScriptableObject
    {
        public virtual string Name => name;

        /// <summary>
        /// На выходе получим индекс новой сущности
        /// </summary>
        /// <param name="world"></param>
        /// <returns></returns>
        public int Create(in EcsWorld world)
        {
            var entity = world.NewEntity();
            world.GetPool<EcsName>().Add(entity).value = Name;
            Install(in world, in entity);
            return entity;
        }

        /// <summary>
        /// Накинуть все нужнные компоненты для сущности
        /// </summary>
        /// <param name="world"></param>
        /// <param name="entity"></param>
        protected abstract void Install(in EcsWorld world, in int entity);
    }
}