using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Offset from the player's position
    public float smoothSpeed = 5.0f; // Smoothing factor for camera movement

    void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        Vector3 desiredPosition = target.position + offset;

        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Set the camera's position to the smoothed position
        transform.position = smoothedPosition;

        // Make the camera look at the player's position
        transform.LookAt(target);
    }
}
