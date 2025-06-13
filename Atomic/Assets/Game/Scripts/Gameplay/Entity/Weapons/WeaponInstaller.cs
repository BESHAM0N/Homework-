using Atomic.Elements;
using Atomic.Entities;
using Game.Context;
using Modules.Gameplay;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class WeaponInstaller : SceneEntityInstaller<IWeaponEntity>
    {
        [SerializeField] private SceneEntity _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Ammo _ammo;
        
        protected override void Install(IWeaponEntity entity)
        {
            entity.AddBulletPrefab(_bulletPrefab);
            InstallFire(entity, GameContext.Instance);
        }
        
        private void InstallFire(IWeaponEntity entity, GameContext gameContext)
        {
            entity.AddAmmo(_ammo);
            entity.AddFirePoint(_firePoint);
            entity.AddFireEvent(new BaseEvent());
            entity.AddFireCondition(new AndExpression(_ammo.Exists));
            entity.AddFireAction(new BaseAction(() =>
            {
                if (entity.GetFireCondition().Invoke())
                {
                    FireUseCase.FireBullet(entity, gameContext);
                    _ammo.SpendOne();
                    entity.GetFireEvent().Invoke();
                }
            }));
        }
    }
}