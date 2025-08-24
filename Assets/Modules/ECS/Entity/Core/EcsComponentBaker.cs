using UnityEngine;

namespace Leopotam.EcsLite
{
    public abstract class EcsComponentBaker<T> : MonoBehaviour, IEcsComponentBaker where T : struct
    {
        public void Bake(EcsWorld world, int entity)
        {
            EcsPool<T> pool = world.GetPool<T>();

            if (pool.Has(entity)) pool.Get(entity) = Bake();
            else pool.Get(entity) = Bake();
        }

        protected abstract T Bake();
    }
}