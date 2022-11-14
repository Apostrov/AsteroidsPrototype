using UnityEngine;

namespace Asteroids.Move
{
    public interface IMovable
    {
        void SetMoveVector(Vector2 moveVector);
        void RotateTowards(Vector2 direction);
    }
}