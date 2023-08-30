using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathGameSine : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _textFields;
    [SerializeField] private TMP_InputField _inputField;
    private float _angle;  // Note that we're using a float here, not an int
    private float _hiddenAnswer;  // This is also a float

    private void Start()
    {
        CreateNewQuestion();
    }

    private void CalculateAnswer()
    {
        // Sine function (note that Mathf.Sin expects an angle in radians)
        _hiddenAnswer = Mathf.Sin(_angle * Mathf.Deg2Rad);
    }

    public void AnswerQuestion()
    {
        if (float.TryParse(_inputField.text, out float userAnswer) && Mathf.Approximately(userAnswer, _hiddenAnswer))
        {
            _textFields[2].text = "Correct!";
        }
        else
        {
            _textFields[2].text = "Wrong, the correct answer is " + _hiddenAnswer.ToString("F2");  // Rounded to two decimal places
        }
    }

    public void NextQuestion()
    {
        CreateNewQuestion();
    }

    public void CreateNewQuestion()
    {
        // Random angle between 0 and 90 degrees, rounded to 2 decimal places
        _angle = Mathf.Round(Random.Range(0f, 90f) * 100f) / 100f;

        _textFields[0].text = _angle.ToString("F2") + "°";  // Display the angle
        _textFields[1].text = "sin(?)";  // Indicates to the player that they need to find the sine
        _textFields[2].text = "Solve";

        CalculateAnswer();
    }
}
