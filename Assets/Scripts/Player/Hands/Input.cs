using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Hands
{
    public class Input : MonoBehaviour
    {
        private const string Grip = "Grip";
        private const string Trigger = "Trigger";

        [SerializeField] private Animator animator;

        [SerializeField] private InputActionProperty gripAction;

        [SerializeField] private InputActionProperty activateAction;

        private void Update()
        {
            var gripValue = gripAction.action.ReadValue<float>();
            var actionValue = activateAction.action.ReadValue<float>();

            animator.SetFloat(Grip, gripValue);
            animator.SetFloat(Trigger, actionValue);
        }
    }
}

