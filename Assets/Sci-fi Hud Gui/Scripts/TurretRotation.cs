using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRotation : MonoBehaviour
{
    public Button _rotateUpButton;
    public Button _rotateDownButton;
    private const float _ROTATION_AMOUNT = 5f;
    private const float _MIN_ROTATION = 0f;
    private const float _MAX_ROTATION = 90f;

    [SerializeField] private AudioSource _rotateUpAudioSource;
    [SerializeField] private AudioSource _rotateDownAudioSource;

    private void Start()
    {
        _rotateUpButton.onClick.AddListener(RotateUp);
        _rotateDownButton.onClick.AddListener(RotateDown);
    }

    public void RotateUp()
    {
        float newRotation = Mathf.Min(transform.eulerAngles.x + _ROTATION_AMOUNT, _MAX_ROTATION);
        SetRotation(newRotation);

        // Play sound effect for rotating up
        if (_rotateUpAudioSource != null)
        {
            _rotateUpAudioSource.Play();
        }
    }

    public void RotateDown()
    {
        float newRotation = Mathf.Max(transform.eulerAngles.x - _ROTATION_AMOUNT, _MIN_ROTATION);
        SetRotation(newRotation);

        // Play sound effect for rotating down
        if (_rotateDownAudioSource != null)
        {
            _rotateDownAudioSource.Play();
        }
    }

    private void SetRotation(float rotation)
    {
        transform.eulerAngles = new Vector3(rotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}


