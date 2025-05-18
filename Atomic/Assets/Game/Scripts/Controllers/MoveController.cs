using Atomic.Entities;
using Modules.Common;
using SampleGame;
using UnityEngine;

namespace Game.Scripts.Controllers
{
    public sealed class MoveController : MonoBehaviour
    {
        [SerializeField] private Joystick _moveJoystick;
        [SerializeField] private Joystick _rotateJoystick;
        [SerializeField] private SceneEntity _sceneEntity;
        private void FixedUpdate()
        {
            var moveInput = _moveJoystick.Direction;
            var moveDir = new Vector3(moveInput.x, 0f, moveInput.y);
            _sceneEntity.GetMoveDirection().Value = moveDir;
            _sceneEntity.GetRotateDirection().Value = moveDir;

            var rotateInput = _rotateJoystick.Direction;
            var rotateDir = new Vector3(rotateInput.x, 0f, rotateInput.y);

            _sceneEntity.GetRotateDirection().Value = rotateDir != Vector3.zero ? rotateDir : moveDir;
        }
    }
}