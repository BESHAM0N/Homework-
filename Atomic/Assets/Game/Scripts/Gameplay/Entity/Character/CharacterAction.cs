using Atomic.Elements;
using Atomic.Entities;
using SampleGame;

namespace Game.Gameplay
{
    public sealed class FireAction : IAction
    {
        private readonly IEntity _entity;

        public FireAction(IEntity entity)
        {
            _entity = entity;
        }

        public void Invoke()
        {
            if (_entity.GetFireCondition().Invoke())
            {
                _entity.GetCurrentWeapon().GetFireAction().Invoke();
                _entity.GetFireEvent().Invoke();
            }
        }
    }
}