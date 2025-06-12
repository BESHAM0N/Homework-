using Atomic.Elements;
using Atomic.Entities;
using Game.Scripts.GameContext;
using Game.Scripts.Gameplay.Entity.Weapons;
using UnityEngine;

namespace SampleGame.PickUps.Ammo
{
    public sealed class AmmoPickUpInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private int _clips = 50;

        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.AddTransform(transform);
            entity.AddInteractibleTag();
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (WeaponUseCase.AddClips(character, _clips))
                    gameObject.SetActive(false);
                //gameContext.GetEntityPool().Return(entity);
            }));
        }
    }
}