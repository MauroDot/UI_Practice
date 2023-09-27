using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flux : MonoBehaviour
{
    public float _minAlpha = 0.3f;
    public float _maxAlpha = 1f;
    public float _fluctuationSpeed = 1f;
    public float _colorChangeSpeed = 1f; // Speed for color transition

    private Image _image;
    private float _currentAlpha;
    private bool _increasingAlpha = true;
    private Color _targetColor;

    private void Start()
    {
        _image = GetComponent<Image>();
        _currentAlpha = _maxAlpha;
        _targetColor = _image.color;
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

        // Reverse the direction of fluctuation when reaching the min or max alpha value.
        if (_currentAlpha <= _minAlpha || _currentAlpha >= _maxAlpha)
        {
            _increasingAlpha = !_increasingAlpha;

            // Start changing to a new random color
            StopCoroutine("ChangeToNewColor");
            StartCoroutine(ChangeToNewColor(new Color(Random.value, Random.value, Random.value, _currentAlpha)));
        }
        else
        {
            Color currentColor = _image.color;
            currentColor.a = _currentAlpha;
            _image.color = currentColor;
        }
    }

    private IEnumerator ChangeToNewColor(Color newColor)
    {
        float progress = 0;
        Color initialColor = _image.color;

        while (progress < 1)
        {
            _image.color = Color.Lerp(initialColor, newColor, progress);
            progress += _colorChangeSpeed * Time.deltaTime;
            yield return null;
        }

        _image.color = newColor;
        _targetColor = newColor;
    }
}


