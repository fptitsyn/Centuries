using CharacterControls;
using UnityEngine;
using Interact;

namespace Player
{
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CharacterController))]
    public class PlayerStateMachine : StateMachine
    {
        public Vector3 velocity;
        public float MovementSpeed = 5f;
        public float JumpForce = 5f;
        public float LookRotationDampFactor = 10f;
        public Transform MainCamera { get; private set; }
        public InputReader InputReader { get; private set; }
        public Animator Animator { get; private set; }
        public CharacterController Controller { get; private set; }

        [SerializeField]
        public Transform Slot;

        public PickableItem PickedItem;

        private void Start()
        {
            MainCamera = Camera.main.transform;

            InputReader = GetComponent<InputReader>();
            Animator = GetComponent<Animator>();
            Controller = GetComponent<CharacterController>();
            
            SwitchState(new PlayerMoveState(this));
        }

    }
}