using UnityEngine;

namespace Asteroids.Player.Move
{
    public interface IInputMovable
    {
        void SetMoveVector(Vector3 moveVector);
        void SetRotation(Vector3 rotationEuler);
        Vector3 GetPosition();
        Quaternion GetRotation();
    }
}