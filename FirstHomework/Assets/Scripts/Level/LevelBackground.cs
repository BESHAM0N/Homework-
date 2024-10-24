using UnityEngine;

namespace ShootEmUp
{
    public sealed class LevelBackground : MonoBehaviour
    {
        [SerializeField] private Params _params;

        private float _startPositionY;
        private float _endPositionY;
        private float _movingSpeedY;
        private float _positionX;
        private float _positionZ;
        private Transform _playerTransform;

        private void Awake()
        {
            InitializeParameters();
        }

        private void FixedUpdate()
        {
            MoveBackground();
            ResetStartPlayerPosition();
        }

        private void InitializeParameters()
        {
            _startPositionY = _params.StartPositionY;
            _endPositionY = _params.EndPositionY;

            _movingSpeedY = _params.MovingSpeedY;
            _playerTransform = transform;

            var position = _playerTransform.position;
            _positionX = position.x;
            _positionZ = position.z;
        }

        private void MoveBackground()
        {
            transform.position -= new Vector3(0, _movingSpeedY * Time.fixedDeltaTime, 0);
        }

        private void ResetStartPlayerPosition()
        {
            if (_playerTransform.position.y <= _endPositionY)
                _playerTransform.position = new Vector3(_positionX, _startPositionY, _positionZ);
        }
    }
}