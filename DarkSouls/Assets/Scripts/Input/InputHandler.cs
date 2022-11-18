using UnityEngine;
using UnityEngine.InputSystem;

namespace DarkSouls
{
    public class InputHandler : IInputHandler
    {
        private StandaloneInputScheme inputScheme;

        private Vector2 movementInput;
        private Vector2 cameraInput;

        public float Horizontal { get; private set; }
        public float Vertical { get; private set; }
        public float MoveAmount { get; private set; }
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }
        
        public void Enable()
        {
            if (inputScheme == null)
                InitInputScheme();
            
            inputScheme.Enable();
        }

        public void Disable()
        {
            inputScheme.Disable();
        }

        private void InitInputScheme()
        {
            inputScheme = new StandaloneInputScheme();
            inputScheme.PlayerMovement.Movement.performed += UpdateMovementInput;
            inputScheme.CameraMovement.Movement.performed += UpdateCameraInput;
        }

        private void UpdateMovementInput(InputAction.CallbackContext inputCallback)
        {
            movementInput = inputCallback.ReadValue<Vector2>();
        }
        
        private void UpdateCameraInput(InputAction.CallbackContext inputCallback)
        {
            cameraInput = inputCallback.ReadValue<Vector2>();
        }

        public void Tick()
        {
            UpdateInputValues();
        }

        private void UpdateInputValues()
        {
            Horizontal = movementInput.x;
            Vertical = movementInput.y;
            MoveAmount = Mathf.Clamp01(Mathf.Abs(Horizontal) + Mathf.Abs(Vertical));
            MouseX = cameraInput.x;
            MouseY = cameraInput.y;
        }
    }
}