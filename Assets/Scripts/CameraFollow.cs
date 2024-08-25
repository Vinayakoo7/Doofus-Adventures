using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public Transform doofus; // Reference to the Doofus GameObject
    public Vector3 offset = new Vector3(0, 10, -10); // we can adjust it as required
    public float smoothSpeed = 0.125f; // Smooth movement speed

    private void LateUpdate()
    {
        if (doofus == null)
        {
            Debug.LogError("Doofus Transform not assigned");
            return;
        }
        // Desired position of the camera
        Vector3 desiredPosition = doofus.position + offset;
        // Smoothly interpolate between the camera's current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        // Set the camera's position
        transform.position = smoothedPosition;
        // Make sure the camera always looks at Doofus
        transform.LookAt(doofus);
    }
}
