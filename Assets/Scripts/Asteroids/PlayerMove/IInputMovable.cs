using UnityEngine;

namespace Asteroids.PlayerMove
{
    public interface IInputMovable
    {
        void SetMoveVector(Vector3 moveVector);
        void SetRotation(Vector3 rotationEuler);
        Quaternion GetRotation();
    }
}