using PlayerMovement.CharacterControls;
using UnityEngine;

namespace PlayerMovement
{
    [RequireComponent(typeof(InputReader))]
    // [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : StateMachine
    {
        public Vector3 velocity;
        public float movementSpeed = 5f;
        public float lookRotationDampFactor = 10f;
        public Transform MainCamera { get; set; }
        public InputReader InputReader { get; private set; }
        // public Animator Animator { get; private set; }
        public CharacterController Controller { get; private set; }

        private void Start()
        {
            MainCamera = Camera.main.transform;
            InputReader = GetComponent<InputReader>();
            // Animator = GetComponent<Animator>();
            Controller = GetComponent<CharacterController>();
            
            SwitchState(new PlayerMoveState(this));
        }
    }
}