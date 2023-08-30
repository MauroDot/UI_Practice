using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathGameDivision : MonoBehaviour
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
        _hiddenAnswer = _number1 / _number2;  // Division operation
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
        // Ensure _number2 is never zero and that _number1 is a multiple of _number2
        do
        {
            _number2 = Random.Range(1, 13);  // 1 to 12, avoiding zero
            _number1 = _number2 * Random.Range(2, 13);  // Ensures a whole number result
        } while (_number1 % _number2 != 0);

        _textFields[0].text = _number1.ToString();
        _textFields[1].text = _number2.ToString();
        _textFields[2].text = "Solve";
        CalculateAnswer();
    }
}
