using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    // Movement
    public float movementSpeed = 5f;
    public float rotationSpeed = 50f;

    // Sound
    public AudioSource turretAudioSource;  // Assign this in the inspector.
    public AudioClip turretMoveClip;  // Assign this in the inspector.

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Rotation movement
        transform.Rotate(Vector3.up * moveHorizontal * rotationSpeed * Time.deltaTime);

        // Play sound when moving and stop when not moving
        if (moveHorizontal != 0)
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
