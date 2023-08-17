using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretRotation : MonoBehaviour
{
    public Button _rotateUpButton;    // Drag the UI Button for rotating up in the Inspector
    public Button _rotateDownButton;  // Drag the UI Button for rotating down in the Inspector
    private const float _ROTATION_AMOUNT = 5f; // The rotation amount per button click
    private const float _MIN_ROTATION = 0f;     // Lower limit on the X-axis
    private const float _MAX_ROTATION = 80f;    // Upper limit on the X-axis

    private void Start()
    {
        // Assign button click events
        _rotateUpButton.onClick.AddListener(RotateUp);
        _rotateDownButton.onClick.AddListener(RotateDown);
    }

    // Rotate the turret 5 degrees upwards on the X-axis, without exceeding MAX_ROTATION
    public void RotateUp()
    {
        float newRotation = Mathf.Min(transform.eulerAngles.x + _ROTATION_AMOUNT, _MAX_ROTATION);
        SetRotation(newRotation);
    }

    // Rotate the turret 5 degrees downwards on the X-axis, without going below MIN_ROTATION
    public void RotateDown()
    {
        float newRotation = Mathf.Max(transform.eulerAngles.x - _ROTATION_AMOUNT, _MIN_ROTATION);
        SetRotation(newRotation);
    }

    // Sets the X-axis rotation ensuring that the rotation value stays in the desired range.
    private void SetRotation(float rotation)
    {
        transform.eulerAngles = new Vector3(rotation, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}

