using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class WordScrambleChallenge : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text _questionText;
    [SerializeField] private TMP_InputField _answerInputField;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _roundText;
    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _feedbackText;
    [SerializeField] private Button _submitAnswerButton;

    [Header("Game Settings")]
    [SerializeField] private int _rounds = 3;
    [SerializeField] private int _timerPerRound = 30;

    [Header("Words By Difficulty")]
    [SerializeField] private string[] _easyWords;
    [SerializeField] private string[] _mediumWords;
    [SerializeField] private string[] _hardWords;

    private int _currentRound = 0;
    private int _score = 0;
    private bool _isPlaying = false;
    private string _currentWord;

    [Header("Difficulty Selection")]
    [SerializeField] private TMP_Dropdown _difficultyDropdown;
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _restartButton;

    private bool _gameStarted = false;

    public enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    private Difficulty _currentDifficulty = Difficulty.Easy;

    private void Start()
    {
        _submitAnswerButton.interactable = false;

        // Setup event listeners
        _difficultyDropdown.onValueChanged.AddListener(OnDifficultyChanged);
        _playButton.onClick.AddListener(StartGame);
        _restartButton.onClick.AddListener(RestartScene);

        // Initial UI state
        _playButton.interactable = true;
        _difficultyDropdown.interactable = true;
    }

    private void OnDifficultyChanged(int index)
    {
        switch (index)
        {
            case 0:
                SetDifficulty(Difficulty.Easy);
                break;
            case 1:
                SetDifficulty(Difficulty.Medium);
                break;
            case 2:
                SetDifficulty(Difficulty.Hard);
                break;
        }
    }

    public void SetDifficulty(Difficulty difficulty)
    {
        _currentDifficulty = difficulty;
    }

    public void StartGame()
    {
        if (!_gameStarted)
        {
            _gameStarted = true;

            // Make the Submit button interactable since the game is starting
            _submitAnswerButton.interactable = true;

            StartNewRound();

            // Make Play button and Dropdown inaccessible after the game starts
            _playButton.interactable = false;
            _difficultyDropdown.interactable = false;
        }
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
            EndGame();
        }
    }

    private void EndGame()
    {
        _isPlaying = false;
        _scoreText.text = $"Total Score: {_score}";

        // Reset the game's state for next play
        _currentRound = 0;
        _score = 0;
        _questionText.text = ""; // Clear the last word

        // Prevent submitting answers
        _submitAnswerButton.interactable = false;

        // Reactivate Play button and Dropdown for next round
        _playButton.interactable = true;
        _difficultyDropdown.interactable = true;
        _gameStarted = false;
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

    public void RestartScene()
    {
        // Restart the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void GenerateScrambledWord()
    {
        switch (_currentDifficulty)
        {
            case Difficulty.Easy:
                _currentWord = _easyWords[Random.Range(0, _easyWords.Length)];
                break;
            case Difficulty.Medium:
                _currentWord = _mediumWords[Random.Range(0, _mediumWords.Length)];
                break;
            case Difficulty.Hard:
                _currentWord = _hardWords[Random.Range(0, _hardWords.Length)];
                break;
        }

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
        Debug.Log($"WordScrambleChallenge Score: {_score}");
        return _score;
    }
}

