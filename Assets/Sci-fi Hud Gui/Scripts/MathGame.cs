using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MathGame : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text questionText;
    [SerializeField] private TMP_InputField answerInputField;
    [SerializeField] private TMP_Text timerText;
    [SerializeField] private TMP_Text roundText;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text feedbackText; // New UI element to show feedback

    [Header("Game Settings")]
    [SerializeField] private int rounds = 3;
    [SerializeField] private int timerPerRound = 30;
    private int currentRound = 0;
    private int _score = 0;
    private bool isPlaying = false;

    private int correctAnswer;

    [Header("Audio Settings")]
    [SerializeField] private AudioSource buttonAudioSource; // Drag and drop the AudioSource component here
    [SerializeField] private AudioClip buttonClickSound; // Drag and drop the sound effect clip here

    private void Start()
    {
        // Check if the AudioSource is attached, if not, add it
        if (buttonAudioSource == null)
        {
            buttonAudioSource = gameObject.AddComponent<AudioSource>();
        }

        StartNewRound();
    }

    private void StartNewRound()
    {
        if (currentRound < rounds)
        {
            isPlaying = true;  // This line is added

            currentRound++;
            roundText.text = $"Round: {currentRound}/{rounds}";
            scoreText.text = $"Score: {_score}";
            StartCoroutine(RoundTimer());
            GenerateQuestion();
        }
        else
        {
            // End the game here and show final score
            scoreText.text = $"Total Score: {_score}";
            // Save the score
            ProfileManager.Instance.AddScoreToCurrentProfile(_score);
            ProfileManager.Instance.UpdateStatsText();
        }
    }

    private IEnumerator RoundTimer()
    {
        int timeLeft = timerPerRound;
        while (timeLeft > 0 && isPlaying)
        {
            timerText.text = $"Time: {timeLeft}s";
            yield return new WaitForSeconds(1);
            timeLeft--;
        }

        // Time's up for this round
        isPlaying = false;  // This line is added
        StartNewRound();
    }

    private void GenerateQuestion()
    {
        int num1 = Random.Range(0, 10);
        int num2 = Random.Range(0, 10);
        correctAnswer = num1 + num2;

        questionText.text = $"{num1} + {num2} = ?";
    }

    public void SubmitAnswer()
    {
        PlayButtonClickSound(); // Play the button click sound

        if (int.Parse(answerInputField.text) == correctAnswer)
        {
            _score += 5;
            feedbackText.text = "Correct! + 5 Points";
        }
        else
        {
            _score -= 3;
            feedbackText.text = "Incorrect! - 3 Points";
        }

        // Hide feedback after 2 seconds
        StartCoroutine(HideFeedbackAfterSeconds(2));
        GenerateQuestion();
    }

    private IEnumerator HideFeedbackAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        feedbackText.text = "";  // Clear feedback text
    }

    public void StartGameOnClick()
    {
        if (!isPlaying)
        {
            StartNewRound();
        }
    }

    public int GetScore()
    {
        Debug.Log($"MathGame Score: {_score}");
        return _score;
    }

    private void PlayButtonClickSound()
    {
        if (buttonAudioSource && buttonClickSound)
        {
            buttonAudioSource.PlayOneShot(buttonClickSound);
        }
    }
}
