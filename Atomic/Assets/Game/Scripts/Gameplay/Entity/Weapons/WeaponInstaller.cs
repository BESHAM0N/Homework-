using Atomic.Entities;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;

        protected override void Install(IWeaponEntity entity)
        {
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddFirePoint(_firePoint);
        }
    }
}