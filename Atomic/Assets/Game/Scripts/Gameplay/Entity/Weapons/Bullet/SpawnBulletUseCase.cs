using Atomic.Entities;
using Game.Context;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class SpawnBulletUseCase
    {
        public static IEntity SpawnBullet(in IGameContext context, in Vector3 position, in Quaternion rotation)
        {
            IEntity bullet = context.GetBulletPool().Rent();
            Transform bulletTransform = bullet.GetTransform();
            bulletTransform.SetPositionAndRotation(position, rotation);

            bullet.GetLifeTime().Reset();
            bullet.GetMoveDirection().Value = bulletTransform.forward;

            return bullet;
        }

        public static void UnspawnBullet(in IGameContext context, in IEntity bullet)
        {
            context.GetBulletPool().Return(bullet);
        }
    }
}