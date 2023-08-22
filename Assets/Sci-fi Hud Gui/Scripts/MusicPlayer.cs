using System.Collections;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource _audioSource;
    public TMP_Text _trackNameText;
    public AudioClip[] _tracks;
    public TMP_Dropdown _trackDropdown;
    public Toggle _repeatToggle;
    public Button _shuffleOnButton;
    public Button _shuffleOffButton;

    private bool _isPaused = false;
    private bool _isRepeating = false;
    private bool _isShuffling = false;
    private int _currentTrackIndex = 0;

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

        // Assign click event handlers for shuffle buttons
        _shuffleOnButton.onClick.AddListener(TurnShuffleOn);
        _shuffleOffButton.onClick.AddListener(TurnShuffleOff);
    }

    private void Update()
    {
        // Check if the current track has finished playing.
        if (!_audioSource.isPlaying && !_isPaused)
        {
            if (_isRepeating)
            {
                PlayTrack(_currentTrackIndex);
            }
            else
            {
                NextTrack();
            }
        }
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
            _currentTrackIndex = index;
            _audioSource.Stop();
            _audioSource.clip = _tracks[index];
            _audioSource.Play();
            _trackNameText.text = _tracks[index].name;

            // Set the dropdown value to the current track index.
            _trackDropdown.value = _currentTrackIndex;
            _trackDropdown.RefreshShownValue();
        }
    }
    public void NextTrack()
    {
        int nextTrackIndex;

        if (_isShuffling)
        {
            do
            {
                nextTrackIndex = Random.Range(0, _tracks.Length);
            }
            while (nextTrackIndex == _currentTrackIndex); // Ensure the next track isn't the same as the current one
        }
        else
        {
            nextTrackIndex = (_currentTrackIndex + 1) % _tracks.Length;
        }

        PlayTrack(nextTrackIndex);
    }

    public void PreviousTrack()
    {
        int prevTrackIndex = (_currentTrackIndex - 1 + _tracks.Length) % _tracks.Length;
        PlayTrack(prevTrackIndex);
    }

    public void ToggleRepeat()
    {
        _isRepeating = !_isRepeating;
    }

    public void TurnShuffleOn()
    {
        _isShuffling = true;
    }

    public void TurnShuffleOff()
    {
        _isShuffling = false;
    }
}








