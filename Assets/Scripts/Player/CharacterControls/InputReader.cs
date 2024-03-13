using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace CharacterControls
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        public Vector2 mouseDelta;
        public Vector2 moveComposite;

        public Action OnJumpPerformed;
        public Action OnInteractPerformed;

        private Controls _controls;

        private void OnEnable()
        {
            if (_controls != null)
            {
                return;
            }

            _controls = new Controls();
            _controls.Player.SetCallbacks(this);
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnJump(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }
            
            OnJumpPerformed?.Invoke();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            moveComposite = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (!context.performed)
            {
                return;
            }

            OnInteractPerformed?.Invoke();
        }
    }
}
