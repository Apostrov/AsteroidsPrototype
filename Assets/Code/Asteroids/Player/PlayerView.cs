using Asteroids.Move;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerView : MonoBehaviour, IMovable
    {
        private Vector2 _moveVector;

        private void Update()
        {
            transform.Translate(_moveVector, Space.World);
        }

        public void SetMoveVector(Vector2 moveVector)
        {
            _moveVector = moveVector;
        }

        public void RotateTowards(Vector2 direction)
        {
            transform.rotation = Quaternion.LookRotation(Vector3.forward, direction.normalized);
        }
    }
}