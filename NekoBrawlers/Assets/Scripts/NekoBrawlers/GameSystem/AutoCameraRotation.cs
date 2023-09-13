using UnityEngine;

namespace GameSystem.UI
{
    public class AutoCameraRotation : MonoBehaviour
    {
        public float rotationSpeed = 10.0f;

        void Update()
        {
            // Rotate the object around its Y-axis.
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
    }
}

