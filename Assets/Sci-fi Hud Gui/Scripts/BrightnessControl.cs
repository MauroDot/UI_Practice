using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrightnessControl : MonoBehaviour
{
    public Slider _brightnessSlider;
    public Image _overlayImage;

    private void Start()
    {
        // Initialize the slider value (optional, for example, set to 0.5 for half transparency).
        _brightnessSlider.value = 1f;

        // Add a listener to the slider to detect changes in its value.
        _brightnessSlider.onValueChanged.AddListener(AdjustBrightness);

        // Adjust initial overlay transparency.
        AdjustBrightness(_brightnessSlider.value);
    }

    void AdjustBrightness(float value)
    {
        float minAlpha = 0.001f; // This ensures that at maximum "darkness", there's still 10% transparency.
        float maxAlpha = 0.9f;
        float range = maxAlpha - minAlpha;

        Color tempColor = _overlayImage.color;
        tempColor.a = maxAlpha - (value * range);
        _overlayImage.color = tempColor;
    }
}
