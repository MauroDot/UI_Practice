using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class TargetScript : MonoBehaviour
{
    [SerializeField] private AudioSource _destructionAudioSource;
    [SerializeField] private AudioClip _destructionSound;

    private void Start()
    {
        if (_destructionAudioSource == null)
        {
            _destructionAudioSource = GetComponent<AudioSource>();
        }

        if (_destructionAudioSource == null)
        {
            _destructionAudioSource = gameObject.AddComponent<AudioSource>();
            _destructionAudioSource.clip = _destructionSound;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision Detected"); // Debug Log to check collision

        if (collision.gameObject.tag == "Cannonball")
        {
            Debug.Log("Cannonball hit the target"); // Debug Log to check tag matching

            AudioSource.PlayClipAtPoint(_destructionSound, transform.position);

            Destroy(gameObject);
        }
    }
}
