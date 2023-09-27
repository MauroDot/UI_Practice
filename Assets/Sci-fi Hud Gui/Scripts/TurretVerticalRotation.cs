using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretVerticalRotation : MonoBehaviour
{
    public float verticalRotationSpeed = 30f;

    // Z-axis vertical limit
    public float maxVerticalRotation = 90f;
    public float minVerticalRotation = -45f;

    private float verticalRotation = 0f;

    // Sound
    public AudioSource turretAudioSource;  // Assign this in the inspector.
    public AudioClip turretMoveClip;  // Assign this in the inspector.

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");
        verticalRotation -= moveVertical * verticalRotationSpeed * Time.deltaTime;
        verticalRotation = Mathf.Clamp(verticalRotation, minVerticalRotation, maxVerticalRotation); // Ensure it stays within the desired range.

        transform.localRotation = Quaternion.Euler(0, 0, verticalRotation);

        // Sound control
        if (moveVertical != 0)
        {
            // Play audio when rotating
            if (!turretAudioSource.isPlaying)
            {
                turretAudioSource.clip = turretMoveClip;
                turretAudioSource.Play();
            }
        }
        else if (turretAudioSource.isPlaying)
        {
            turretAudioSource.Stop();
        }
    }
}
