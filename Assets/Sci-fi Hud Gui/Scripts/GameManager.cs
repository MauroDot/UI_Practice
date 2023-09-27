using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Gameplay UI")]
    [SerializeField] private TMP_Text _textField;
    [SerializeField] private TMP_Text _countdownText;
    [SerializeField] private TMP_Text _roundNumberText; // Display current round
    [SerializeField] private TMP_Text _totalScoreText;
    [SerializeField] private GameObject[] _items;
    private GameObject _grid;

    [Header("Game Settings")]
    [SerializeField] private int _rounds = 3;
    private int _currentRound = 0;
    [SerializeField] private int _score;
    private int _totalScore = 0;
    private bool _isPlaying = false;

    [Header("Sound Settings")]
    [SerializeField] private AudioClip _timerBeep;
    private AudioSource _audioSource;

    private void Start()
    {
        _grid = GameObject.Find("Grid");
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
        StartRound(); // Directly start the first round when game begins
    }

    private void StartRound()
    {
        if (_currentRound < _rounds)
        {
            _currentRound++;
            _roundNumberText.text = "Round: " + _currentRound; // Display current round
            StartGame();
        }
        else
        {
            _totalScoreText.text = "Total Score: " + _totalScore.ToString();
        }
    }

    public void StartGame()
    {
        if (_isPlaying) return;

        _isPlaying = true;
        _score = 0;
        _textField.text = "0";

        foreach (Transform child in _grid.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < 30; i++)
        {
            GameObject item = Instantiate(_items[Random.Range(0, 3)], transform.position, Quaternion.identity);
            item.transform.SetParent(_grid.transform, false);
        }

        foreach (Transform child in _grid.transform)
        {
            Image cover = child.GetComponentInChildren<Image>();
            if (cover != null)
                cover.gameObject.SetActive(true);
        }

        StartCoroutine(GameFlow());
    }

    private IEnumerator GameFlow()
    {
        _countdownText.text = "5";
        for (int i = 5; i >= 1; i--)
        {
            foreach (Transform child in _grid.transform)
            {
                Button0 buttonScript = child.GetComponent<Button0>();
                if (buttonScript != null)
                    buttonScript.Reveal();
            }

            _audioSource.PlayOneShot(_timerBeep);
            _countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        foreach (Transform child in _grid.transform)
        {
            Button0 buttonScript = child.GetComponent<Button0>();
            if (buttonScript != null)
                buttonScript.Hide();
        }

        _countdownText.text = "7";
        for (int i = 7; i >= 1; i--)
        {
            _countdownText.text = i.ToString();
            yield return new WaitForSeconds(1);
        }

        _totalScore += _score;
        EndGameSession(_score);
        _isPlaying = false;
        yield return new WaitForSeconds(2);
        StartRound();
    }

    public void TotalScore(int value)
    {
        if (!_isPlaying) return;

        _score += value;
        _textField.text = _score.ToString();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public bool IsGamePlaying()
    {
        return _isPlaying;
    }

    public void EndGameSession(int gameScore)
    {
        // Add the game score to the current profile's score.
        ProfileManager.Instance.AddScoreToCurrentProfile(gameScore);
    }

    public int GetTotalScore()
    {
        Debug.Log($"GameManager Score: {_totalScore}");
        return _totalScore;
    }
}
