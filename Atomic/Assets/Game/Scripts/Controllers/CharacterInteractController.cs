using Atomic.Contexts;
using Atomic.Entities;
using DG.Tweening.Core;
using Game.Scripts.PlayerContext;
using SampleGame;
using SampleGame.Common.Interact;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class CharacterInteractController : IContextInit<IPlayerContext>, IContextUpdate
    {
        private IEntity _character;
        
        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
        }

        public void OnUpdate(IContext context, float deltaTime)
        {
            if (_character.GetTargetInteractible().Value != null)
            {
                Debug.Log($"таргет -- {_character.GetTargetInteractible().Value.Name}");
                InteractUseCase.InteractAsCharacter(_character);
            }
        }
    }
}