using UnityEngine;

namespace Asteroids.Player.Move
{
    public class PlayerMoverView : MonoBehaviour, IInputMovable
    {
        [SerializeField] private Transform ToMove;
        [SerializeField] private Transform ToRotate;

        private Vector3 _moveVector;
        private Vector3 _rotationEuler;
        private Camera _mainCamera;
        
        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            ToMove.Translate(_moveVector * Time.deltaTime, Space.World);
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

        public Vector3 GetPosition()
        {
            return ToMove.position;
        }

        public Quaternion GetRotation()
        {
            return ToRotate.rotation;
        }
    }
}