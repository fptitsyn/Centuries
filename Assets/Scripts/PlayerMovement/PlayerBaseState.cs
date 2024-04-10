using UnityEngine;

namespace PlayerMovement
{
    public abstract class PlayerBaseState : State
    {
        protected readonly PlayerStateMachine StateMachine;

        protected PlayerBaseState(PlayerStateMachine stateMachine)
        {
            StateMachine = stateMachine;
        }

        protected void CalculateMoveDirection()
        {
            var forward = StateMachine.MainCamera.forward;
            var right = StateMachine.MainCamera.right;
            
            Vector3 cameraForward = new(forward.x, 0, forward.z);
            Vector3 cameraRight = new(right.x, 0, right.z);

            Vector3 moveDirection = cameraForward.normalized * StateMachine.InputReader.moveComposite.y +
                                    cameraRight.normalized * StateMachine.InputReader.moveComposite.x;

            StateMachine.velocity.x = moveDirection.x * StateMachine.movementSpeed;
            StateMachine.velocity.z = moveDirection.z * StateMachine.movementSpeed;
        }

        protected void FaceLookingDirection()
        {
            // StateMachine.MainCamera.eulerAngles = new Vector3(StateMachine.lookRotationDampFactor *
            //                                                   StateMachine.InputReader.mouseDelta.x, StateMachine.lookRotationDampFactor * StateMachine.InputReader.mouseDelta.y, 0f);
            
            Vector3 camera = StateMachine.MainCamera.forward;
            Vector3 faceDirection = new Vector3(camera.x, 0f, camera.z);
            
            if (faceDirection == Vector3.zero)
            {
                return;
            }
            
            StateMachine.transform.rotation = Quaternion.Slerp(StateMachine.transform.rotation, 
                Quaternion.LookRotation(faceDirection), StateMachine.lookRotationDampFactor * Time.deltaTime);
        }

        // protected void MoveCamera()
        // {
        //     Vector3 pan = 
        // }
        
        protected void Move()
        {
            StateMachine.Controller.Move(StateMachine.velocity * Time.deltaTime);
        }
    }
}