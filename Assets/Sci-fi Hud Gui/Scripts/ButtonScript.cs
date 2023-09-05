using System.Collections;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] private int _buttonValue;
    [SerializeField] private PinNumber _pinNumber;

    public void DisplayButtonValue()
    {
        _pinNumber.AddDigit(_buttonValue.ToString());
    }
}


