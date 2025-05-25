using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.GameContext;
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
            GameContext gameContext = GameContext.Instance;
            entity.AddBulletPrefab(_bulletPrefab);
            entity.AddFirePoint(_firePoint);
            entity.AddFireEvent(new BaseEvent());
            entity.AddFireCondition(new Const<bool>(true));
            
            entity.AddFireAction( new BaseAction(() => 
            {
                if (entity.GetFireCondition().Invoke())
                {
                    FireUseCase.FireBullet(entity, gameContext);
                    entity.GetFireEvent().Invoke();
                }
            }));
        }
    }
}