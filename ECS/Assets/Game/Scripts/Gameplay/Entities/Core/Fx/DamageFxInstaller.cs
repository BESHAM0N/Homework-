using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGame
{
    public class DamageFxInstaller : EcsViewInstaller
    {
        [SerializeField] private ParticleSystem _damageParticle;
        [SerializeField] private ParticleSystem _fireEffect;
        
        public override void Install(in EcsWorld world, in int entity)
        {
            ref var fx = ref world.GetPool<DamageFxView>().Add(entity);
            fx.particle = _damageParticle;
            fx.fireEffect = _fireEffect;
        }
    }
}