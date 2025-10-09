using ECSGame;
using Leopotam.EcsLite;
using UnityEngine;

namespace ECSGamek
{
    public class AttackAnimationReceiver: MonoBehaviour
    {
        public EcsWorld World;
      
        public void OnAttackAnimation()
        {
            var evtEnt = World.NewEntity();
            ref var req = ref World.GetPool<ProjectileSpawnRequest>().Add(evtEnt);
        }
    }
}