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
            // _stateMachine.Animator.CrossFadeInFixedTime(_moveBlendTreeHash, CrossFadeDuration);
        }

        public override void Tick()
        {    
            CalculateMoveDirection();
            FaceLookingDirection();
            Move();
            
            // _stateMachine.Animator.SetFloat(_moveSpeedHash, _stateMachine.InputReader.moveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);
        }

        public override void Exit()
        {
            
        }
    }
}