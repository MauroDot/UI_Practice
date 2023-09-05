using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserAccount : MonoBehaviour
{
    [SerializeField] private TMP_InputField[] _userInputFields;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private GameObject _login;
    [SerializeField] private GameObject _create;
    [SerializeField] private TMP_Text _debugText;
    [SerializeField] private string _username;
    [SerializeField] private string _password;

    private void Start()
    {
        _debugText.text = "";
    }

    public void LoginAcct()
    {
        // Validate if inputs are empty first
        if (string.IsNullOrEmpty(_userInputFields[2].text) || string.IsNullOrEmpty(_userInputFields[3].text))
        {
            _debugText.text = "Input fields cannot be empty";
            _userInputFields[2].text = "";
            _userInputFields[3].text = "";
            return;
        }

        // Validate if the account is created
        if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
        {
            _debugText.text = "No Account Created, try again";
            _userInputFields[2].text = "";
            _userInputFields[3].text = "";
            return;
        }

        // Validate credentials
        if (_userInputFields[2].text == _username && _userInputFields[3].text == _password)
        {
            _debugText.text = "Login Success";
            return;
        }
        else
        {
            _debugText.text = "Wrong Username or Password, try again";
            _userInputFields[2].text = "";
            _userInputFields[3].text = "";
            return;
        }
    }
    public void CreateAcct()
    {
        if(_userInputFields[0].text.Length > 3 && _userInputFields[1].text.Length > 3)
        {
            _username = _userInputFields[0].text;
            _password = _userInputFields[1].text;
            _debugText.text = "Success Account Created";
            Debug.Log("Username is " + _username + "and your ppassword was " + _password);
            OpenLoginAcctMenu();
        }
        else
        {
            _debugText.text = "Username must be at least 4 digits or more";
            _userInputFields[0].text = "";
            _userInputFields[1].text = "";
        }
    }
    public void OpenCreateAcctMenu()
    {
        _login.SetActive(false);
        _create.SetActive(true);
    }

    public void OpenLoginAcctMenu()
    {
        _login.SetActive(true);
        _create.SetActive(false);
    }
}
