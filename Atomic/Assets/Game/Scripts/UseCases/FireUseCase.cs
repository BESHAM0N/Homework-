using Atomic.Entities;
using Game.Scripts.GameContext;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public static class FireUseCase
    {
        public static IEntity FireBullet(this IWeaponEntity entity, in IGameContext gameContext)
        {
            Transform firePoint = entity.GetFirePoint();
            return SpawnBulletUseCase.SpawnBullet(gameContext, firePoint.position, firePoint.rotation);
        }
    }
}