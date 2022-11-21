using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Input
{
    public class PlayerInputEventManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference FireAction;
        [SerializeField] private InputActionReference MoveAction;

        private event Action<Vector2> OnMove;
        private event Action OnFire;

        private void Awake()
        {
            MoveAction.action.performed += MoveActionPerformed;
            FireAction.action.performed += FireActionPerformed;
        }

        public void AddOnMoveListener(Action<Vector2> callback)
        {
            OnMove += callback;
        }

        public void AddOnFireListener(Action callback)
        {
            OnFire += callback;
        }

        public void ClearSubscriptions()
        {
            MoveAction.action.performed -= MoveActionPerformed;
            FireAction.action.performed -= FireActionPerformed;
        }

        private void MoveActionPerformed(InputAction.CallbackContext context)
        {
            OnMove?.Invoke(context.ReadValue<Vector2>());
        }

        private void FireActionPerformed(InputAction.CallbackContext context)
        {
            OnFire?.Invoke();
        }
    }
}