using System.Collections.Generic;
using System.Collections;
using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Header("Ball Spawning")]
    [SerializeField] private GameObject _spawnPoint;
    [SerializeField] private GameObject _ball;
    private bool _dropBall = true;

    [Header("Menu Settings")]
    [SerializeField] private GameObject _settingMenu;
    private bool _menuActive = false;

    [Header("Volume Settings")]
    [SerializeField] private Slider _sliderVol;
    public float _minVolume = 0f;
    public float _maxVolume = 1f;
    public float _defaultVolume = 1f;

    [Header("Brightness Settings")]
    [SerializeField] private Image _brightnessOverlay;
    [SerializeField] private Slider _sliderBrightness;
    [SerializeField] private float _minAlpha = 0.1f; // Minimum transparency, 0 is fully transparent, 1 is fully opaque.
    [SerializeField] private float _maxAlpha = 0.9f; // Maximum transparency, set to less than 1 to ensure it doesn't go fully black.

    [SerializeField] private GameObject[] _balls;  // Array of ball prefabs
    [SerializeField] private GameObject[] _spawnPoints;  // Array of spawn points

    private void Start()
    {
        SwitchMenu();
        StartCoroutine("DropBall");

        // Set the default volume
        SetVolume(_defaultVolume);

        // Attach the slider listener
        if (_sliderVol != null)
        {
            _sliderVol.value = _defaultVolume;
            _sliderVol.onValueChanged.AddListener(OnVolumeSliderValueChanged);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            TurnMenuOff();
        }
    }

    private void SetVolume(float volume)
    {
        // Clamp the volume value within the specified range.
        volume = Mathf.Clamp(volume, _minVolume, _maxVolume);

        // Set the volume
        AudioListener.volume = volume;
    }

    private void OnVolumeSliderValueChanged(float value)
    {
        SetVolume(value);
    }

    public void AdjustBrightness()
    {
        var tempColor = _brightnessOverlay.color;

        // Remap the slider's value (which is assumed to be between 0 and 1) to the range between _minAlpha and _maxAlpha.
        float alphaRange = _maxAlpha - _minAlpha;
        tempColor.a = _minAlpha + _sliderBrightness.value * alphaRange;

        _brightnessOverlay.color = tempColor;
    }

    public void TurnMenuOff()
    {
        _menuActive = !_menuActive;
        if (_menuActive)
        {
            Time.timeScale = 0;
            SwitchMenu();
        }
        else
        {
            Time.timeScale = 1;
            SwitchMenu();
        }
    }

    public void SwitchMenu()
    {
        _settingMenu.SetActive(_menuActive);
    }

    IEnumerator DropBall()
    {
        while (_dropBall)
        {
            GameObject randomBallPrefab = _balls[Random.Range(0, _balls.Length)];  // Select a random ball prefab
            GameObject randomSpawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];  // Select a random spawn point

            GameObject ballInstance = Instantiate(randomBallPrefab, randomSpawnPoint.transform.position, randomSpawnPoint.transform.rotation);

            yield return new WaitForSeconds(0.1f);  // Adjust as needed
            Destroy(ballInstance, 30.0f);
        }
    }
}
