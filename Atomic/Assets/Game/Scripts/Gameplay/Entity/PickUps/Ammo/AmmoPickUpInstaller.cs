using Atomic.Elements;
using Atomic.Entities;
using Game.Context;
using SampleGame;
using UnityEngine;

namespace Game.Gameplay
{
    public sealed class AmmoPickUpInstaller : SceneEntityInstaller
    {
        [SerializeField]
        private int _clips = 10;

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