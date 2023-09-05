using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonballHitFx : MonoBehaviour
{
    [SerializeField] private AudioSource _collisionAudioSource; // AudioSource component for playing sound
    [SerializeField] private AudioClip _collisionSound; // AudioClip that you want to play

    // Start is called before the first frame update
    private void Start()
    {
        // If AudioSource is not set, try to get it from the GameObject
        if (_collisionAudioSource == null)
        {
            _collisionAudioSource = GetComponent<AudioSource>();
        }

        // Initialize AudioSource if it is still null
        if (_collisionAudioSource == null)
        {
            _collisionAudioSource = gameObject.AddComponent<AudioSource>();
            _collisionAudioSource.clip = _collisionSound;
        }
    }

    // This method will be automatically called when another object collides with this one
    private void OnCollisionEnter(Collision collision)
    {
        // Play the collision sound
        _collisionAudioSource.Play();
    }
}

