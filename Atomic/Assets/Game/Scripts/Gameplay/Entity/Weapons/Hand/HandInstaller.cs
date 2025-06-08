using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public class HandInstaller :  SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private float _hitRadius = 0.2f;
        [SerializeField] private Transform _firePoint;
        
        protected override void Install(IWeaponEntity entity)
        {
            entity.AddHitRadius(_hitRadius);
            entity.AddFirePoint(_firePoint);
        }
    }
}