using Atomic.Contexts;
using Atomic.Entities;
using Game.Gameplay;
using Game.Context;
using SampleGame;

namespace Game.Controllers
{
    public sealed class CharacterInteractController : IContextInit<IGameContext>, IContextUpdate
    {
        private IEntity _character;
        
        public void Init(IGameContext context)
        {
            _character = GameContext.Instance.GetCharacter();
        }

        public void OnUpdate(IContext context, float deltaTime)
        { 
            if (_character.GetTrigger() != null)
            {
                InteractUseCase.InteractAsCharacter(_character);
            }
        }
    }
}