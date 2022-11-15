using Asteroids.UpdateLoop;
using UnityEngine;

namespace Asteroids.Move
{
    public class MovePlayerInputListener : IUpdate
    {
        private readonly Data.MovementConfig _movementConfig;
        private readonly IInputMovable[] _toMove;

        private Vector2 _inputVector;
        private float _currentSpeed;
        private float _currentAcceleration;

        public MovePlayerInputListener(Data.MovementConfig movementConfig, IInputMovable[] toMove)
        {
            _movementConfig = movementConfig;
            _toMove = toMove;
        }

        public void Update()
        {
            if (_inputVector.y > 0f)
            {
                _currentAcceleration += _movementConfig.AccelerationGrowSpeed * Time.deltaTime;
                _currentAcceleration = Mathf.Clamp(_currentAcceleration, 0f, _movementConfig.MaxAcceleration);
                _currentSpeed = Mathf.Clamp(_currentSpeed + _currentAcceleration, 0f, _movementConfig.MaxSpeed);
            }
            else
            {
                _currentAcceleration = 0f;
                _currentSpeed = Mathf.Clamp(_currentSpeed - _movementConfig.Breaking * Time.deltaTime, 0f,
                    _movementConfig.MaxSpeed);
            }

            UpdateMovablesMoveVector(_currentSpeed);
        }

        public void UpdateMoveInput(Vector2 inputVector)
        {
            _inputVector = inputVector;
            var zAngle = -1f * inputVector.x * _movementConfig.AngularSpeed;

            UpdateMovablesRotation(zAngle);
        }

        private void UpdateMovablesRotation(float zAngle)
        {
            foreach (var movable in _toMove)
            {
                movable.SetRotation(new Vector3(0f, 0f, zAngle));
            }
        }

        private void UpdateMovablesMoveVector(float speed)
        {
            foreach (var movable in _toMove)
            {
                movable.SetMoveVector(new Vector3(0f, speed, 0f));
            }
        }
    }
}