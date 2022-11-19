using UnityEngine;

namespace Asteroids.GameField
{
    [RequireComponent(typeof(Renderer))]
    public class TeleportOnInvisibleListener : MonoBehaviour
    {
        [SerializeField] private GameObject Root;

        private Camera _camera;
        private bool _quitting;

        public void Awake()
        {
            _camera = Camera.main;
        }

        private void OnBecameInvisible()
        {
            if (_quitting) // fix null ref on game exit
                return;
            TelepotBackToScreen.Teleport(_camera, Root);
        }

        private void OnApplicationQuit()
        {
            _quitting = true;
        }
    }
}