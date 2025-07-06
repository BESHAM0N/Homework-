using Atomic.Contexts;
using Atomic.Entities;
using Game.Context;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Controllers
{
    public class CharacterAttackController : IContextInit<IGameContext>, IContextUpdate
    {
        private Joystick _attackJoystick;
        private IEntity _character;

        public void Init(IGameContext context)
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