using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathGameSubtraction : MonoBehaviour
{
    [SerializeField] private TMP_Text[] _textFields;
    [SerializeField] private TMP_InputField _inputField;
    private int _number1;
    private int _number2;
    private int _hiddenAnswer;

    private void Start()
    {
        CreateNewQuestion();
    }

    private void CalculateAnswer()
    {
        _hiddenAnswer = _number1 - _number2;  // Subtraction operation
    }

    public void AnswerQuestion()
    {
        if (int.TryParse(_inputField.text, out int userAnswer) && userAnswer == _hiddenAnswer)
        {
            _textFields[2].text = "Correct!";
        }
        else
        {
            _textFields[2].text = "Wrong, the correct answer is " + _hiddenAnswer;
        }
    }

    public void NextQuestion()
    {
        CreateNewQuestion();
    }

    public void CreateNewQuestion()
    {
        _number1 = Random.Range(10, 50);  // Chose a larger range to minimize negative answers
        _number2 = Random.Range(2, _number1);  // Make sure it's smaller than _number1 to avoid negative answers
        _textFields[0].text = _number1.ToString();
        _textFields[1].text = _number2.ToString();
        _textFields[2].text = "Solve";
        CalculateAnswer();
    }
}

