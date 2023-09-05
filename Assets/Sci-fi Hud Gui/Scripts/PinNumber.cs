using System.Collections;
using System.Collections.Generic; // This is needed to use List
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PinNumber : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private TMP_Text _textBox;
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private TMP_Text _lockedText;

    [Header("Buttons")]
    [SerializeField] private Button[] _keypadButtons;

    [Header("Audio")]
    [SerializeField] private AudioClip _buttonPressClip;
    [SerializeField] private AudioClip _clearButtonClip;
    [SerializeField] private AudioClip _pinAcceptedClip;
    [SerializeField] private AudioClip _pinRejectedClip;
    private AudioSource audioSource;

    private string _secretPIN = "123456";
    private string _truePIN;
    private float _invalidPinTime = 10.0f; // countdown time
    private bool _isCountdownActive = false;

    private void Start()
    {
        _textBox.text = "Enter PIN";
        audioSource = GetComponent<AudioSource>();
        if (_countdownText) _countdownText.gameObject.SetActive(false);
        if (_lockedText) _lockedText.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_isCountdownActive)
        {
            _invalidPinTime -= Time.deltaTime;
            _countdownText.text = Mathf.CeilToInt(_invalidPinTime).ToString();

            if (_invalidPinTime <= 0)
            {
                _isCountdownActive = false;
                _countdownText.gameObject.SetActive(false);
                _lockedText.gameObject.SetActive(false);
                EnableButtons();
                Clear();
            }
        }
    }

    public void AddDigit(string number)
    {
        PlaySound(_buttonPressClip);
        _textBox.text = "";
        _truePIN += number;
        _textBox.text = _truePIN;
    }

    public void Submit()
    {
        if (_secretPIN == _truePIN)
        {
            _textBox.text = "PIN Accepted";
            PlaySound(_pinAcceptedClip);
            _truePIN = null;
        }
        else
        {
            _textBox.text = "Invalid Pin";
            PlaySound(_pinRejectedClip);
            StartCountdown();
            _truePIN = null;
        }
    }

    private void StartCountdown()
    {
        if (!_countdownText) return;

        _invalidPinTime = 10.0f;
        _isCountdownActive = true;
        _countdownText.gameObject.SetActive(true);
        _lockedText.gameObject.SetActive(true);
        DisableButtons();
    }

    public void Clear()
    {
        PlaySound(_clearButtonClip);
        _textBox.text = "Enter PIN";
        _truePIN = null;
    }

    private void PlaySound(AudioClip clip)
    {
        if (clip && audioSource)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    private void DisableButtons()
    {
        foreach (Button btn in _keypadButtons)
        {
            btn.interactable = false;
        }
    }

    private void EnableButtons()
    {
        foreach (Button btn in _keypadButtons)
        {
            btn.interactable = true;
        }
    }
}
