using Modules.Common;
using UnityEngine;

namespace Game.Context
{
    public class InputUseCase
    {
        public static Vector3 GetMoveDirection(Joystick moveJoystick)
        {
            var moveInput = moveJoystick.Direction;
            return new Vector3(moveInput.x, 0f, moveInput.y);
        }

        public static Vector3 GetRotateDirection(Joystick moveJoystick, Joystick attackJoystick)
        {
            var moveInput = moveJoystick.Direction;
            var attackInput = attackJoystick.Direction;

            var moveDir = new Vector3(moveInput.x, 0f, moveInput.y);
            var attackDir = new Vector3(attackInput.x, 0f, attackInput.y);

            return attackDir != Vector3.zero ? attackDir : moveDir;
        }

        public static bool IsFire(Joystick attackJoystick)
        {
            var input = new Vector3(attackJoystick.Direction.x, 0f, attackJoystick.Direction.y);
            return input != Vector3.zero;
        }

        public static Vector3 GetAttackRotateDirection(Joystick attackJoystick)
        {
            var input = attackJoystick.Direction;
            var direction = new Vector3(input.x, 0f, input.y);
            return direction;
        }
    }
}