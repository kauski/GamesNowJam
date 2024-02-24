using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target;  // The target the camera follows
    public float distance = 5.0f;  // Distance from the target
    public float height = 2.0f;    // Height above the target
    public float rotationDamping = 3.0f;  // Smooth rotation speed
    public float rotationSpeed = 2.0f;  // Mouse rotation speed

    void Start()
    {
        // Hide the cursor and lock it to the game window
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        if (!target)
            return;

        HandleCameraRotation();

        // Calculate desired camera position
        Vector3 wantedPosition = target.position - target.forward * distance + Vector3.up * height;

        // Smoothly interpolate to the desired position
        transform.position = Vector3.Lerp(transform.position, wantedPosition, Time.deltaTime * rotationDamping);

        // Look at the target
        transform.LookAt(target);
    }

    void HandleCameraRotation()
    {
        // Rotate the target based on mouse input
        float horizontalInput = Input.GetAxis("Mouse X") * rotationSpeed;
        target.Rotate(0, horizontalInput, 0);

        float verticalInput = Input.GetAxis("Mouse Y") * rotationSpeed;
        target.Rotate(-verticalInput, 0, 0);

        target.eulerAngles = new Vector3(target.eulerAngles.x, target.eulerAngles.y, 0);
    }
}