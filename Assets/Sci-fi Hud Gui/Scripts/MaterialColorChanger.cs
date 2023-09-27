using System.Collections.Generic;
using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class MaterialColorChanger : MonoBehaviour
{
    private MeshRenderer _meshRenderer;
    private float _changeInterval = 1.5f; // Time in seconds over which color will change
    private float _elapsedTime = 1.5f; // Elapsed time since last color change
    private Color _currentColor;
    private Color _targetColor;

    void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
        _currentColor = _meshRenderer.material.color;
        _targetColor = GetRandomColor();
        StartCoroutine(ChangeMaterialColor());
    }

    private IEnumerator ChangeMaterialColor()
    {
        while (true)
        {
            _elapsedTime += Time.deltaTime; // increment the elapsed time
            float t = _elapsedTime / _changeInterval; // calculate the normalized time
            _meshRenderer.material.color = Color.Lerp(_currentColor, _targetColor, t); // interpolate

            // When we reach the target color, reset and choose a new target color
            if (t >= 1.5f)
            {
                _elapsedTime = 0.0f;
                _currentColor = _targetColor;
                _targetColor = GetRandomColor();
            }

            yield return null; // wait until next frame
        }
    }

    private Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value, 1.0f);
    }
}
