using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource _audioSource;
    public TMP_Text _trackNameText;
    public AudioClip[] _tracks;
    public TMP_Dropdown _trackDropdown; // Reference to the UI Dropdown for the track selection.

    private bool _isPaused = false;

    private void Start()
    {
        // Setup the Dropdown options based on the track names.
        _trackDropdown.ClearOptions();
        List<string> trackNames = new List<string>();
        foreach (AudioClip track in _tracks)
        {
            trackNames.Add(track.name);
        }
        _trackDropdown.AddOptions(trackNames);

        // Set the default track to the first one.
        PlayTrack(0);
    }

    public void PlayPause()
    {
        if (_isPaused)
        {
            _audioSource.UnPause();
        }
        else
        {
            _audioSource.Pause();
        }

        _isPaused = !_isPaused;
    }

    public void PlayTrack(int index)
    {
        if (index >= 0 && index < _tracks.Length)
        {
            _audioSource.Stop();
            _audioSource.clip = _tracks[index];
            _audioSource.Play();
            _trackNameText.text = _tracks[index].name;
        }
    }

    public void NextTrack()
    {
        int nextTrackIndex = (_trackDropdown.value + 1) % _tracks.Length;
        _trackDropdown.value = nextTrackIndex;
        PlayTrack(nextTrackIndex);
    }

    public void PreviousTrack()
    {
        int prevTrackIndex = (_trackDropdown.value - 1 + _tracks.Length) % _tracks.Length;
        _trackDropdown.value = prevTrackIndex;
        PlayTrack(prevTrackIndex);
    }
}



