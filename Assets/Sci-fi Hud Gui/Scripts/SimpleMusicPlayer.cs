using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class SimpleMusicPlayer : MonoBehaviour
{
    public AudioClip[] songs;
    private int currentSongIndex;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (songs.Length > 0)
        {
            audioSource.clip = songs[currentSongIndex];
        }
    }

    public void Play()
    {
        if (audioSource.isPlaying) return;
        if (audioSource.clip == null && songs.Length > 0)
        {
            audioSource.clip = songs[currentSongIndex];
        }
        audioSource.Play();
    }

    public void Pause()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void Next()
    {
        if (songs.Length == 0) return;

        currentSongIndex = (currentSongIndex + 1) % songs.Length;
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }

    public void Previous()
    {
        if (songs.Length == 0) return;

        currentSongIndex--;
        if (currentSongIndex < 0)
        {
            currentSongIndex = songs.Length - 1;
        }
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();
    }
}
