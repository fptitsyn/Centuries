using UnityEngine;

namespace Player
{
    public class PlayerJumpState : PlayerBaseState
    {
        private readonly int _jumpHash = Animator.StringToHash("Jump");
        private const float CrossFadeDuration = 0.1f;
        
        public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _stateMachine.velocity =
                new Vector3(_stateMachine.velocity.x, _stateMachine.JumpForce, _stateMachine.velocity.z);
            
            // _stateMachine.Animator.CrossFadeInFixedTime(_jumpHash, CrossFadeDuration);
        }

        public override void Tick()
        {
            ApplyGravity();

            if (_stateMachine.velocity.y <= 0f)
            {
                _stateMachine.SwitchState(new PlayerFallState(_stateMachine));
            }
            
            FaceMoveDirection();
            Move();
        }

        public override void Exit() { }
    }
}