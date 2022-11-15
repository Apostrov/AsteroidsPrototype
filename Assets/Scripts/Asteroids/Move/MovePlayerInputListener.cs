using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Move
{
    public class MovePlayerInputListener : IUpdate
    {
        private readonly Data.MovementConfig _movementConfig;
        private readonly IInputMovable _player;

        private Vector2 _inputVector;
        private float _currentSpeed;
        private float _currentAcceleration;
        
        private Quaternion _lastRotation;

        public MovePlayerInputListener(Data.MovementConfig movementConfig, IInputMovable player)
        {
            _movementConfig = movementConfig;
            _player = player;
        }

        public void Update()
        {
            if (_inputVector.y > 0f)
            {
                _currentAcceleration += _movementConfig.AccelerationGrowSpeed * Time.deltaTime;
                _currentAcceleration = Mathf.Clamp(_currentAcceleration, 0f, _movementConfig.MaxAcceleration);
                _currentSpeed = Mathf.Clamp(_currentSpeed + _currentAcceleration, 0f, _movementConfig.MaxSpeed);
                
                UpdateMovablesMoveVector(_currentSpeed, false);
            }
            else
            {
                _currentAcceleration = -999f;
                _currentSpeed = Mathf.Clamp(_currentSpeed - _movementConfig.BreakForce * Time.deltaTime, 0f,
                    _movementConfig.MaxSpeed);
                
                UpdateMovablesMoveVector(_currentSpeed, true);
            }
        }

        public void UpdateMoveInput(Vector2 inputVector)
        {
            _inputVector = inputVector;
            var zAngle = -1f * inputVector.x * _movementConfig.AngularSpeed;

            UpdateMovablesRotation(zAngle);
        }

        private void UpdateMovablesRotation(float zAngle)
        {
            _player.SetRotation(new Vector3(0f, 0f, zAngle));
        }

        private void UpdateMovablesMoveVector(float speed, bool isBreaking)
        {
            var moveVector = new Vector3(0f, speed, 0f);
            if (!isBreaking)
            {
                _lastRotation = _player.GetRotation();
            }
            _player.SetMoveVector(_lastRotation * moveVector);
        }
    }
}