using UnityEngine;

namespace Leopotam.EcsLite
{
    public abstract class EcsComponentBaker<T> : MonoBehaviour, IEcsComponentBaker where T : struct
    {
        public void Bake(EcsWorld world, int entity)
        {
            EcsPool<T> pool = world.GetPool<T>();
            var value = Bake();

            if (pool.Has(entity)) pool.Get(entity) = Bake();
            //else pool.Get(entity) = Bake();
            else pool.Add(entity) = value;
        }

        protected abstract T Bake();
    }
}