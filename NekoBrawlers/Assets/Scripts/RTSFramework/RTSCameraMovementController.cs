using UnityEngine;
using UnityEngine.InputSystem;

namespace RTSFramework.InputSystem
{
    public class RTSCameraMovementController : MonoBehaviour
    {
        [SerializeField]
        private float moveSpeed = 5.0f; // Adjust this to control the movement speed.
        private Gamepad gamepad;
        private Vector3 movement = new Vector3();


        private void Start()
        {
            gamepad = Gamepad.current;
            movement = new Vector3();
        }

        void Update()
        {
            // Get the input values for horizontal and vertical movement.
            Vector2 leftStickInput = gamepad.leftStick.ReadValue();
            movement.x = leftStickInput.x;
            movement.z = leftStickInput.y;

            // Normalize the movement vector to ensure consistent speed in all directions.
            movement.Normalize();

            // Translate the camera's position based on the input and movement speed.
            transform.Translate(movement * moveSpeed * Time.deltaTime);
        }
    }

}
