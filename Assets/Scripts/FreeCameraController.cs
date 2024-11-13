using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCameraController : MonoBehaviour
{
    public float movementSpeed = 10f;      // Speed of camera movement
    public float rotationSpeed = 100f;     // Speed of camera rotation
    public float zoomSpeed = 5f;           // Speed of zoom
    public float minZoomDistance = 5f;     // Minimum zoom distance
    public float maxZoomDistance = 50f;    // Maximum zoom distance

    private float pitch = 0f;              // Vertical rotation (up/down)
    private float yaw = 0f;                // Horizontal rotation (left/right)
    private Camera cam;

    private void Start()
    {
        cam = Camera.main; // Get the main camera
        if (cam == null)
        {
            Debug.LogError("No main camera found in the scene!");
        }
    }

    private void Update()
    {
        // Move the camera based on WASD keys
        MoveCamera();

        // Rotate the camera based on right mouse button hold
        RotateCamera();

        // Zoom the camera with mouse scroll wheel
        ZoomCamera();
    }

    private void MoveCamera()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrow keys
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrow keys

        Vector3 moveDirection = transform.forward * moveZ + transform.right * moveX;
        transform.position += moveDirection * movementSpeed * Time.deltaTime;
    }

    private void RotateCamera()
    {
        // Check if the right mouse button is held down
        if (Input.GetMouseButton(1))
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Adjust yaw and pitch
            yaw += mouseX;
            pitch -= mouseY;
            pitch = Mathf.Clamp(pitch, -89f, 89f); // Limit vertical rotation to prevent flipping

            // Apply rotation
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }

    private void ZoomCamera()
    {
        // Get scroll wheel input
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Calculate new camera position based on zoom speed
        Vector3 zoomDirection = cam.transform.forward * scroll * zoomSpeed;
        cam.transform.position += zoomDirection;

        // Clamp zoom within minimum and maximum distances
        float distanceFromOrigin = Vector3.Distance(transform.position, cam.transform.position);
        if (distanceFromOrigin < minZoomDistance || distanceFromOrigin > maxZoomDistance)
        {
            // Revert zoom if out of bounds
            cam.transform.position -= zoomDirection;
        }
    }
}
