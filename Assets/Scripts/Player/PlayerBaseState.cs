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

        protected void FaceLookingDirection()
        {
            Vector3 camera = _stateMachine.MainCamera.forward;
            Vector3 faceDirection = new Vector3(camera.x, 0f, camera.z);

            if (faceDirection == Vector3.zero)
            {
                return;
            }
            
            _stateMachine.transform.rotation = Quaternion.Slerp(_stateMachine.transform.rotation, 
                Quaternion.LookRotation(faceDirection), _stateMachine.LookRotationDampFactor * Time.deltaTime);
        }

        protected void Move()
        {
            _stateMachine.Controller.Move(_stateMachine.velocity * Time.deltaTime);
        }
    }
}