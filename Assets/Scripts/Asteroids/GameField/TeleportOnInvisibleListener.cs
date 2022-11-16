using UnityEngine;

namespace Asteroids.GameField
{
    [RequireComponent(typeof(Renderer))]
    public class TeleportOnInvisibleListener : MonoBehaviour
    {
        [SerializeField] private GameObject Root;
        private Camera _camera;

        public void Start()
        {
            _camera = Camera.main;
        }

        private void OnBecameInvisible()
        {
            TelepotBackToScreen.Teleport(_camera, Root);
        }
    }
}