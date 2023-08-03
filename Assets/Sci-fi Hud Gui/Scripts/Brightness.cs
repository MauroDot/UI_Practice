using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class Brightness : MonoBehaviour
{
    public Slider _brightnessSlider;

    public PostProcessProfile _brightness;
    public PostProcessLayer _layer;

    AutoExposure _exposure;

    private void Start()
    {
        _brightness.TryGetSettings(out _exposure);
        AdjustBrightness(_brightnessSlider.value);
    }

    public void AdjustBrightness(float value)
    {
        if(value != 0)
        {
            _exposure.keyValue.value = value;
        }
        else
        {
            _exposure.keyValue.value = .05f;
        }
    }
}








