using Atomic.Entities;
using SampleGame;

namespace Game.Gameplay
{
    public static class FireUseCase
    {
        public static IEntity FireBullet(this IWeaponEntity entity)
        {
            var bulletPrefab = entity.GetBulletPrefab();
            var firePoint = entity.GetFirePoint();
            return SceneEntity.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}