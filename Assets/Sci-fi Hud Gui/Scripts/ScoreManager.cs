using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text _scoreText;      // Reference to the score display text
    public TMP_Text _timerText;      // Reference to the timer display text
    public TMP_Text _endGameText;    // Reference to display 'You Win' or 'You Lose'

    public int _targetScore = 30;    // Score needed to win the game
    private int _currentScore = 0;   // Current player score

    public float _gameTime = 180.0f; // 3 minutes in seconds

    private bool _gameStarted = false;  // To check if game has started
    private bool _gameEnded = false;    // To check if game has ended

    private void Start()
    {
        _endGameText.gameObject.SetActive(false);
        UpdateScoreDisplay();
        UpdateTimerDisplay();
    }

    void Update()
    {
        if (_gameStarted && !_gameEnded)
        {
            _gameTime -= Time.deltaTime;
            UpdateTimerDisplay();

            if (_gameTime <= 0)
            {
                _gameTime = 0;
                EndGame();
            }
        }
    }

    // Method to start the game (Called when Start Button is pressed)
    public void StartGame()
    {
        _gameStarted = true;
        _gameEnded = false;
        _currentScore = 0;
        _gameTime = 180.0f;  // Reset timer to 3 minutes
        _endGameText.gameObject.SetActive(false);
    }


    // Called when cannonball scores
    public void IncreaseScore(int points)
    {
        if (_gameStarted && !_gameEnded)
        {
            _currentScore += points;
            UpdateScoreDisplay();

            if (_currentScore >= _targetScore)
            {
                EndGame(true);
            }
        }
    }

    private void EndGame(bool win = false)
    {
        _gameEnded = true;
        if (win)
        {
            _endGameText.text = "You Win!";
        }
        else
        {
            _endGameText.text = "You Lose!";
        }
        _endGameText.gameObject.SetActive(true);
    }

    private void UpdateScoreDisplay()
    {
        _scoreText.text = "Score: " + _currentScore;
    }

    private void UpdateTimerDisplay()
    {
        _timerText.text = "Time: " + Mathf.CeilToInt(_gameTime) + "s";
    }

    // Reset the game (To be called from a restart button)
    public void RestartGame()
    {
        StartGame();
        UpdateScoreDisplay();
        UpdateTimerDisplay();
    }

    public void RestartScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
