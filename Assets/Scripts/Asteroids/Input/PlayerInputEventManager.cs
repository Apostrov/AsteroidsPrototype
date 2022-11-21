using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Input
{
    public class PlayerInputEventManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference FireAction;
        [SerializeField] private InputActionReference MoveAction;
        [SerializeField] private InputActionReference LaserAction;

        private event Action<Vector2> OnMove;
        private event Action OnFire;
        private event Action OnLaser;

        private void Awake()
        {
            MoveAction.action.performed += MoveActionPerformed;
            FireAction.action.performed += FireActionPerformed;
            LaserAction.action.performed += LaserActionPerformed;
        }

        public void AddOnMoveListener(Action<Vector2> callback)
        {
            OnMove += callback;
        }

        public void AddOnFireListener(Action callback)
        {
            OnFire += callback;
        }

        public void AddOnLaserListener(Action callback)
        {
            OnLaser += callback;
        }

        public void ClearSubscriptions()
        {
            MoveAction.action.performed -= MoveActionPerformed;
            FireAction.action.performed -= FireActionPerformed;
            LaserAction.action.performed -= LaserActionPerformed;
        }

        private void MoveActionPerformed(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }

        private void FireActionPerformed(InputAction.CallbackContext context)
        {
            OnFire?.Invoke();
        }

        private void LaserActionPerformed(InputAction.CallbackContext context)
        {
            OnLaser?.Invoke();
        }
    }
}