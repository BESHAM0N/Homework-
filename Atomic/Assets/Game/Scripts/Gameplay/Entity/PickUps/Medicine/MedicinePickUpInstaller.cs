using Atomic.Elements;
using Atomic.Entities;
using SampleGame;
using UnityEngine;
using Game.Context;

namespace Game.Gameplay
{
    public class MedicinePickUpInstaller: SceneEntityInstaller
    {
        [SerializeField]
        private int _hp = 25;

        public override void Install(IEntity entity)
        {
            var gameContext = GameContext.Instance;

            entity.AddTransform(transform);
            entity.AddInteractibleTag();
            entity.AddInteractAction(new BaseAction<IEntity>(character =>
            {
                if (HealthUseCase.AddHitPoints(character, _hp))
                    gameObject.SetActive(false);
                //gameContext.GetEntityPool().Return(entity);
            }));
        }
    }
}