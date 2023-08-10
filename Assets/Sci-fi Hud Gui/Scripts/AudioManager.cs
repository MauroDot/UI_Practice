using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public Button audioButton;
    public Sprite audioOnSprite;
    public Sprite audioOffSprite;

    private bool isAudioOn = false;

    private void Start()
    {
        audioButton.onClick.AddListener(ToggleAudio);
        UpdateButtonSprite();
    }

    private void ToggleAudio()
    {
        isAudioOn = !isAudioOn;

        if (isAudioOn)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }

        UpdateButtonSprite();
    }

    private void UpdateButtonSprite()
    {
        audioButton.image.sprite = isAudioOn ? audioOnSprite : audioOffSprite;
    }
}


