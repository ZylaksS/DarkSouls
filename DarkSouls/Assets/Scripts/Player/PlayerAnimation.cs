using UnityEngine;

namespace DarkSouls.Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimation : MonoBehaviour
    {
        private Animator animator;

        private const string VerticalParameter = "Vertical";
        private const string HorizontalParameter = "Horizontal";
        private const float LocomotionDampTime = 0.1f;

        private int verticalParameterId;
        private int horizontalParameterId;
        
        public bool CanRotate { get; private set; } = true;

        public void Init()
        {
            animator = GetComponent<Animator>();
            verticalParameterId = Animator.StringToHash(VerticalParameter);
            horizontalParameterId = Animator.StringToHash(HorizontalParameter);
        }

        public void UpdateAnimator(float verticalMovement, float horizontalMovement)
        {
            animator.SetFloat(verticalParameterId, verticalMovement, LocomotionDampTime, Time.deltaTime);
            animator.SetFloat(horizontalParameterId, horizontalMovement, LocomotionDampTime, Time.deltaTime);
        }

        public void EnableRotationAvailability() => CanRotate = true;

        public void DisableRotationAvailability() => CanRotate = false;
    }
}