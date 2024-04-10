using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Hands
{
    public class Input : MonoBehaviour
    {
        private const string GRIP = "Grip";
        private const string TRIGGER = "Trigger";

        [SerializeField] private Animator animator;

        [SerializeField] private InputActionProperty gripAction;

        [SerializeField] private InputActionProperty activateAction;

        private void Update()
        {
            var gripValue = gripAction.action.ReadValue<float>();
            var actionValue = activateAction.action.ReadValue<float>();

            animator.SetFloat(GRIP, gripValue);
            animator.SetFloat(TRIGGER, actionValue);
        }
    }
}

