using Game.Core;
using UnityEngine;

namespace DarkSouls.Player
{
    public class PlayerCompositeRoot : CompositeRoot
    {
        [Inject] private InputHandler inputHandler;

        [SerializeField] private PlayerLocomotionSettings locomotionSettings;
        [SerializeField] private Camera gameCamera;
        [SerializeField] private PlayerLocomotionView locomotionView;
        [SerializeField] private PlayerAnimation playerAnimation;

        private PlayerLocomotion playerLocomotion;
        
        public override void Compose()
        {
            this.Inject();
            
            playerLocomotion = new PlayerLocomotion(locomotionSettings.MoveSpeed, locomotionSettings.RotationSpeed);
            playerAnimation.Init();
        }

        private void Update()
        {
            Move();
            Rotate();
            UpdateAnimation();
        }

        private void Move()
        {
            locomotionView.UpdateVelocity(GetLocomotionVelocity());
        }

        private void Rotate()
        {
            if (!playerAnimation.CanRotate) return; 
            
            transform.rotation = playerLocomotion.GetTargetRotation(gameCamera.transform, transform, inputHandler, Time.deltaTime);
        }

        private void UpdateAnimation()
        {
            playerAnimation.UpdateAnimator(inputHandler.MoveAmount, 0);
        }
        
        private Vector3 GetLocomotionVelocity()
        {
            Vector3 moveDirection = playerLocomotion.GetMoveDirection(gameCamera.transform, inputHandler);
            return Vector3.ProjectOnPlane(moveDirection, Vector3.zero);
        }
    }
}