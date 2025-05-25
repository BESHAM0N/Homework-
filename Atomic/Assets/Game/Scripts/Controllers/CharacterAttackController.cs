using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.GameContext;
using Game.Scripts.GameContext.Input;
using Game.Scripts.PlayerContext;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public class CharacterAttackController : IContextInit<IPlayerContext>, IContextUpdate
    {
        private Joystick _attackJoystick;
        private IEntity _character;

        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
            _attackJoystick = context.GetAttackJoystick();
        }

        public void OnUpdate(IContext context, float deltaTime)
        {
            _character.GetFireRotateDirection().Value = InputUseCase.IsFire(_attackJoystick) ? InputUseCase.GetAttackRotateDirection(_attackJoystick) : Vector3.zero;
        }
    }
}