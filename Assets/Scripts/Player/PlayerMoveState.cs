using UnityEngine;

namespace Player
{
    public class PlayerMoveState : PlayerBaseState
    {
        private readonly int _moveSpeedHash = Animator.StringToHash("MoveSpeed");
        private readonly int _moveBlendTreeHash = Animator.StringToHash("MoveBlendTree");
        private const float AnimationDampTime = 0.1f;
        private const float CrossFadeDuration = 0.1f;
        
        public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            _stateMachine.velocity.y = Physics.gravity.y;
            
            _stateMachine.Animator.CrossFadeInFixedTime(_moveBlendTreeHash, CrossFadeDuration);

            _stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
        }

        public override void Tick()
        {
            if (!_stateMachine.Controller.isGrounded)
            {
                _stateMachine.SwitchState(new PlayerFallState(_stateMachine));
            }
            
            CalculateMoveDirection();
            FaceMoveDirection();
            Move();
            
            _stateMachine.Animator.SetFloat(_moveSpeedHash, _stateMachine.InputReader.moveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);
        }

        public override void Exit()
        {
            _stateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
        }

        private void SwitchToJumpState()
        {
            _stateMachine.SwitchState(new PlayerJumpState(_stateMachine));
        }
    }
}