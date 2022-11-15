using Asteroids.Move;
using UnityEngine;

namespace Asteroids.Player
{
    public class PlayerMoverView : MonoBehaviour, IInputMovable
    {
        [SerializeField] private Transform ToMove;
        [SerializeField] private Transform ToRotate;

        private Vector3 _moveVector;
        private Vector3 _rotationEuler;

        private void Update()
        {
            ToMove.Translate(_moveVector * Time.deltaTime, Space.Self);
            ToRotate.Rotate(_rotationEuler * Time.deltaTime, Space.Self);
        }

        public void SetMoveVector(Vector3 moveVector)
        {
            _moveVector = moveVector;
        }

        public void SetRotation(Vector3 rotationEuler)
        {
            _rotationEuler = rotationEuler;
        }
    }
}