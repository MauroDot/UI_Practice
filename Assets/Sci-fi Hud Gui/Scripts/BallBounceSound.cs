using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BallBounceSound : MonoBehaviour
{
    public AudioClip bounceClip;  // Assign the bounce sound clip in the inspector
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Play the bounce sound
        if (bounceClip && audioSource && !audioSource.isPlaying) // Check if the sound isn't already playing to avoid overlap
        {
            audioSource.PlayOneShot(bounceClip);
        }
    }
}
