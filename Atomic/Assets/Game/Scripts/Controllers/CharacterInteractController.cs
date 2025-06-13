using Atomic.Contexts;
using Atomic.Entities;
using Game.Gameplay;
using Game.Context;
using Game.PlayerContext;
using SampleGame;

namespace Game.Controllers
{
    public sealed class CharacterInteractController : IContextInit<IPlayerContext>, IContextUpdate
    {
        private IEntity _character;
        
        public void Init(IPlayerContext context)
        {
            _character = PlayersUseCase.GetCharacter(GameContext.Instance, 1);
        }

        public void OnUpdate(IContext context, float deltaTime)
        { 
            if (_character.GetTargetInteractible().Value != null)
            {
                InteractUseCase.InteractAsCharacter(_character);
            }
        }
    }
}