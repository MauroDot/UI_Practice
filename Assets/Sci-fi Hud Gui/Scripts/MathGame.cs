using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

class MathGame : MonoBehaviour
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
        _hiddenAnswer = _number1 + _number2;
    }
    public void AnswerQuestion()
    {
        if (int.Parse(_inputField.text) == _hiddenAnswer)
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
        _number1 = Random.Range(2, 40);
        _number2 = Random.Range(2, 40);
        _textFields[0].text = _number1.ToString();
        _textFields[1].text = _number2.ToString();
        _textFields[2].text = "Solve";
        CalculateAnswer();
    }
}
