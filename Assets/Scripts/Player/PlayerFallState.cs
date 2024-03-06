using UnityEngine;

namespace Player
{
    public class PlayerFallState : PlayerBaseState
    {
        private readonly int _fallHash = Animator.StringToHash("Fall");
        private const float CrossFadeDuration = 0.1f;
        
        public PlayerFallState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _stateMachine.velocity.y = 0f;
            
            _stateMachine.Animator.CrossFadeInFixedTime(_fallHash, CrossFadeDuration);
        }

        public override void Tick()
        {
            ApplyGravity();
            Move();

            if (_stateMachine.Controller.isGrounded)
            {
                _stateMachine.SwitchState(new PlayerMoveState(_stateMachine));
            }
        }

        public override void Exit() { }
    }
}