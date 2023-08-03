using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine;
using UnityEngine.UI;

public class FluctuatingTransparency : MonoBehaviour
{
    public float _minAlpha = 0.3f; // The minimum alpha value (transparency).
    public float _maxAlpha = 1f;   // The maximum alpha value (opaque).
    public float _fluctuationSpeed = 1f; // The speed at which the transparency fluctuates.

    private Image _image;
    private float _currentAlpha;
    private bool _increasingAlpha = true;

    private void Start()
    {
        _image = GetComponent<Image>();
        _currentAlpha = _maxAlpha;
    }

    private void Update()
    {
        // Update the alpha value based on the fluctuation speed.
        if (_increasingAlpha)
            _currentAlpha += _fluctuationSpeed * Time.deltaTime;
        else
            _currentAlpha -= _fluctuationSpeed * Time.deltaTime;

        // Ensure the alpha value stays within the specified range.
        _currentAlpha = Mathf.Clamp(_currentAlpha, _minAlpha, _maxAlpha);

        // Apply the new alpha value to the UI image's color.
        Color currentColor = _image.color;
        currentColor.a = _currentAlpha;
        _image.color = currentColor;

        // Reverse the direction of fluctuation when reaching the min or max alpha value.
        if (_currentAlpha <= _minAlpha || _currentAlpha >= _maxAlpha)
            _increasingAlpha = !_increasingAlpha;
    }
}


