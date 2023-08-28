using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PinVerification : MonoBehaviour
{
    [SerializeField] private TMP_InputField CreatePin;
    [SerializeField] private TMP_InputField EnterPin;
    [SerializeField] private TMP_Text textOutput;

    public void SetPin()
    {
        if (CreatePin.text.Length != 4) // Check that the PIN is 4 digits long
        {
            textOutput.text = "PIN must be 4 digits!";
            return;
        }
        PlayerPrefs.SetString("pin", CreatePin.text);
        textOutput.text = "PIN Created Successfully!";
    }

    public void VerifyPin()
    {
        string savedPin = PlayerPrefs.GetString("pin", "");

        if (savedPin == "") // Check that a PIN has been set
        {
            textOutput.text = "No PIN has been set.";
            return;
        }

        if (EnterPin.text == savedPin)
        {
            textOutput.text = "PIN Verified!";
        }
        else
        {
            textOutput.text = "Invalid PIN!";
        }
    }
}

