using UnityEngine;

namespace Asteroids.Move
{
    public interface IInputMovable
    {
        void SetMoveVector(Vector3 moveVector);
        void SetRotation(Vector3 rotationEuler);
    }
}