using UnityEngine;

namespace Player
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerStateMachine _stateMachine;

        protected PlayerBaseState(PlayerStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        protected void CalculateMoveDirection()
        {
            var forward = _stateMachine.MainCamera.forward;
            var right = _stateMachine.MainCamera.right;
            
            Vector3 cameraForward = new(forward.x, 0, forward.z);
            Vector3 cameraRight = new(right.x, 0, right.z);

            Vector3 moveDirection = cameraForward.normalized * _stateMachine.InputReader.moveComposite.y +
                                    cameraRight.normalized * _stateMachine.InputReader.moveComposite.x;

            _stateMachine.velocity.x = moveDirection.x * _stateMachine.MovementSpeed;
            _stateMachine.velocity.z = moveDirection.z * _stateMachine.MovementSpeed;
        }

        protected void FaceMoveDirection()
        {
            Vector3 faceDirection = new(_stateMachine.velocity.x, 0f, _stateMachine.velocity.z);

            if (faceDirection == Vector3.zero)
            {
                return;
            }
            
            _stateMachine.transform.rotation = Quaternion.Slerp(_stateMachine.transform.rotation, 
                Quaternion.LookRotation(faceDirection), _stateMachine.LookRotationDampFactor * Time.deltaTime);
        }

        protected void ApplyGravity()
        {
            if (_stateMachine.velocity.y > Physics.gravity.y)
            {
                _stateMachine.velocity.y += Physics.gravity.y * Time.deltaTime;
            }
        }

        protected void Move()
        {
            _stateMachine.Controller.Move(_stateMachine.velocity * Time.deltaTime);
        }
    }
}