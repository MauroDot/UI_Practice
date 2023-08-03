using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{
    public Slider volumeSlider; // Reference to the UI Slider in the game.
    public float minVolume = 0f; // Minimum volume value.
    public float maxVolume = 1f; // Maximum volume value.
    public float defaultVolume = 1f; // Default volume value.

    private void Start()
    {
        // Set the default volume when the game starts.
        SetVolume(defaultVolume);

        // If a UI Slider is assigned, update its value to match the default volume.
        if (volumeSlider != null)
        {
            volumeSlider.value = defaultVolume;
            volumeSlider.onValueChanged.AddListener(OnVolumeSliderValueChanged);
        }
    }

    // Method to set the volume of the game.
    private void SetVolume(float volume)
    {
        // Clamp the volume value within the specified range.
        volume = Mathf.Clamp(volume, minVolume, maxVolume);

        // Update the volume using the AudioListener's volume property.
        AudioListener.volume = volume;
    }

    // Method to handle the UI Slider's value change event.
    private void OnVolumeSliderValueChanged(float value)
    {
        SetVolume(value);
    }
}
