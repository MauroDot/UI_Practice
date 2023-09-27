using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager1 : MonoBehaviour
{
    public static AudioManager1 Instance;

    [SerializeField] private AudioClip defaultButtonClickSound;  // Default sound
    private AudioSource audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Makes sure our AudioManager1 persists between scenes
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
    }

    // Play default button click sound
    public void PlayButtonClickSound()
    {
        audioSource.PlayOneShot(defaultButtonClickSound);
    }

    // Play specific sound
    public void PlaySpecificSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
