using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.CharacterControls
{
    public class InputReader : MonoBehaviour, Controls.IPlayerActions
    {
        public Vector2 mouseDelta;
        public Vector2 moveComposite;

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

        public void OnMove(InputAction.CallbackContext context)
        {
            moveComposite = context.ReadValue<Vector2>();
        }

        public void OnLook(InputAction.CallbackContext context)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }
    }
}
