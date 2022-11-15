using UnityEngine;

namespace Asteroids.Move
{
    public class MovePlayerInputListener
    {
        private readonly Data.MovementConfig _movementConfig;
        private readonly IMovable[] _toMove;

        public MovePlayerInputListener(Data.MovementConfig movementConfig, IMovable[] toMove)
        {
            _movementConfig = movementConfig;
            _toMove = toMove;
        }
        
        public void UpdateMoveInput(Vector2 inputVector)
        {
            var moveVector = inputVector * _movementConfig.Speed * Time.deltaTime;
            foreach (var movable in _toMove)
            {
                movable.SetMoveVector(moveVector);
            }
        }
    }
}