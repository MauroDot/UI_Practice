using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public float rotationSpeed = 50f; // The initial rotation speed, can be adjusted in the Inspector.
    public bool rotateClockwise = true; // Set this to false if you want the circle to rotate counterclockwise.

    void Update()
    {
        // Determine the direction of rotation based on the rotateClockwise variable.
        int direction = rotateClockwise ? 1 : -1;

        // Rotate the object around the Z-axis (assuming it's a 2D circle).
        transform.Rotate(Vector3.forward * direction * rotationSpeed * Time.deltaTime);
    }
}


