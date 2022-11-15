using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Input
{
    public class PlayerInputEventManager : MonoBehaviour
    {
        [SerializeField] private InputActionReference FireAction;
        [SerializeField] private InputActionReference MoveAction;

        private event Action<Vector2> OnMoveVectorChange; 

        private void Awake()
        {
            MoveAction.action.performed += MoveActionPerformed;
        }

        public void SubscribeToMoveVectorChange(Action<Vector2> callback)
        {
            OnMoveVectorChange += callback;
        }

        private void MoveActionPerformed(InputAction.CallbackContext context)
        {
            OnMoveVectorChange?.Invoke(context.ReadValue<Vector2>());
        }
    }
}