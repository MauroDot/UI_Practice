using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Linq;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using TMPro;

public class WordScrambleGame : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _roundText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _feedbackText;
    [SerializeField] private Button _submitAnswerButton; // Add this button in the Unity inspector

    [Header("Game Settings")]
    [SerializeField] private int _rounds = 3;
    [SerializeField] private int _timerPerRound = 30;
    [SerializeField] private string[] _words;  // Add some words in the Unity inspector for the scramble game

    private int _currentRound = 0;
    private int _score = 0;
    private bool _isPlaying = false;
    private string _currentWord;

    private void Start()
    {
        _submitAnswerButton.onClick.AddListener(SubmitAnswer);  // Set up button listener
        StartNewRound();
    }

    private void StartNewRound()
    {
        if (_currentRound < _rounds)
        {
            _isPlaying = true;

            _currentRound++;
            _roundText.text = $"Round: {_currentRound}/{_rounds}";
            _scoreText.text = $"Score: {_score}";
            StartCoroutine(RoundTimer());
            GenerateScrambledWord();
        }
        else
        {
            _isPlaying = false;
            _scoreText.text = $"Total Score: {_score}";

            // Integrate with the ProfileManager
            ProfileManager.Instance.AddScoreToCurrentProfile(_score);
            ProfileManager.Instance.UpdateStatsText();  // Refresh the score display in ProfileManager

            _score = 0;  // Optionally reset the game score if the player wants to play again.
        }
    }

    private IEnumerator RoundTimer()
    {
        int timeLeft = _timerPerRound;
        while (timeLeft > 0 && _isPlaying)
        {
            _timerText.text = $"Time: {timeLeft}s";
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

        _isPlaying = false;
        StartNewRound();
    }

    private void GenerateScrambledWord()
    {
        _currentWord = _words[Random.Range(0, _words.Length)];
        _questionText.text = ScrambleWord(_currentWord);
    }

    private string ScrambleWord(string word)
    {
        char[] chars = word.ToCharArray();
        System.Random rand = new System.Random();
        for (int i = 0; i < chars.Length; i++)
        {
            int randomIndex = rand.Next(chars.Length);
            char temp = chars[randomIndex];
            chars[randomIndex] = chars[i];
            chars[i] = temp;
        }
        return new string(chars);
    }

    public void SubmitAnswer()
    {
        if (_answerInputField.text.Equals(_currentWord, System.StringComparison.OrdinalIgnoreCase))
        {
            _score += 5;
            _feedbackText.text = "Correct! + 5 Points";
        }
        else
        {
            _score -= 3;
            _feedbackText.text = "Incorrect! - 3 Points";
        }

        StartCoroutine(HideFeedbackAfterSeconds(2));
        GenerateScrambledWord();
    }

    private IEnumerator HideFeedbackAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        _feedbackText.text = "";
    }

    public int GetScore()
    {
        Debug.Log($"WordScrambleGame Score: {_score}");
        return _score;
    }
}

