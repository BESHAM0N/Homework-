using Atomic.Contexts;
using Atomic.Entities;
using Game.Scripts.GameContext.Input;
using Game.Scripts.PlayerContext;
using Modules.Common;
using SampleGame;

namespace Game.Scripts.Controllers
{
    public sealed class CharacterMoveController : IContextInit<IPlayerContext>, IContextUpdate
    {
        private IEntity _character;
        private Joystick _moveJoystick;
        private Joystick _attackJoystick;

        public void Init(IPlayerContext context)
        {
            _character = context.GetCharacter();
            _moveJoystick = context.GetMoveJoystick();
            _attackJoystick = context.GetAttackJoystick();
        }
        
        public void OnUpdate(IContext context, float deltaTime)
        {
            var moveDir = InputUseCase.GetMoveDirection(_moveJoystick);
            var rotateDir = InputUseCase.GetRotateDirection(_moveJoystick, _attackJoystick);

            _character.GetMoveDirection().Value = moveDir;
            _character.GetRotateDirection().Value = rotateDir;
        }
    }
}