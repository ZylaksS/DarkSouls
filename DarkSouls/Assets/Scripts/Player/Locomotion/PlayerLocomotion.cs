using UnityEngine;

namespace DarkSouls.Player
{
    public class PlayerLocomotion
    {
        private readonly float moveSpeed;
        private readonly float rotationSpeed;

        public PlayerLocomotion(float moveSpeed, float rotationSpeed)
        {
            this.moveSpeed = moveSpeed;
            this.rotationSpeed = rotationSpeed;
        }

        public Vector3 GetMoveDirection(Transform relativeObject, IInputHandler inputHandler)
        {
            Vector3 MoveDirection = relativeObject.forward * inputHandler.Vertical;
            MoveDirection += relativeObject.right * inputHandler.Horizontal;
            MoveDirection.Normalize();

            return MoveDirection * moveSpeed;
        }

        public Quaternion GetTargetRotation(Transform relativeObject, Transform own, IInputHandler inputHandler,
            float deltaTime)
        {
            float moveOverride = inputHandler.MoveAmount;

            Quaternion targetRotation =
                Quaternion.LookRotation(GetTargetRotationDirection(relativeObject, own, inputHandler));
            return Quaternion.Slerp(own.rotation, targetRotation, rotationSpeed * deltaTime);
        }

        private Vector3 GetTargetRotationDirection(Transform relativeObject, Transform own, IInputHandler inputHandler)
        {
            Vector3 targetRotationDirection = relativeObject.forward * inputHandler.Vertical;
            targetRotationDirection += relativeObject.right * inputHandler.Horizontal;
            targetRotationDirection.Normalize();
            targetRotationDirection.y = 0;

            return targetRotationDirection != Vector3.zero ? targetRotationDirection : own.forward;
        }
    }
}