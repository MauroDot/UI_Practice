using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundUp : MonoBehaviour
{
    public AudioSource audioSource;
    public float rampDuration = 5f; // Time in seconds for the volume to reach full.

    private bool isRamping;
    private float rampStartTime;
    private float startVolume;

    void Start()
    {
        // Ensure the Audio Source is set and get the initial volume.
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
        if (audioSource != null)
        {
            startVolume = audioSource.volume;
        }
    }

    void Update()
    {
        // Check if we are currently ramping up the volume.
        if (isRamping)
        {
            float timeSinceStart = Time.time - rampStartTime;
            if (timeSinceStart >= rampDuration)
            {
                // Clamp the volume to 1.0f to avoid going over.
                audioSource.volume = 1.0f;
                isRamping = false;
            }
            else
            {
                // Calculate the current volume based on the ramp progress.
                float rampProgress = timeSinceStart / rampDuration;
                audioSource.volume = Mathf.Lerp(startVolume, 1.0f, rampProgress);
            }
        }
    }

    public void OnPlayButtonPressed()
    {
        if (!isRamping && audioSource != null)
        {
            // Start the volume ramp up.
            isRamping = true;
            rampStartTime = Time.time;
        }
    }
}

