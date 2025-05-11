using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game.Gameplay
{
    public sealed class CharacterFireAction : IAction
    {
        private readonly IEntity _entity;

        public CharacterFireAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                FireUseCase.FireBullet(_entity.GetPistolWeapon());
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}