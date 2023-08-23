using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextInput : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private TextMeshProUGUI _outputText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputFieldTyping()
    {
        _outputText.text = "Typing...";
    }

    public void InputField()
    {
        _outputText.text = "You entered: " + _inputField.text;
    }
}
