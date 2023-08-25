using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _name;
    [SerializeField] private TMP_InputField _password;
    [SerializeField] private TMP_Text _textOoutput;
    public void InputFieldName()
    {
        PlayerPrefs.SetString("name", _name.text);
    }

    public void InputFieldPassword()
    {
        PlayerPrefs.SetString("password", _password.text);
    }

    public void OutputText()
    {
        _textOoutput.text = "Your Username is " + PlayerPrefs.GetString("name") + " and your password is " + PlayerPrefs.GetString("password");
    }
}
