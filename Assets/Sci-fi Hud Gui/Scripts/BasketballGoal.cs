using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasketballGoal : MonoBehaviour
{
    [SerializeField] private TMP_Text _goalText; // Reference to your TextMeshPro text object. Set this in the inspector.
    [SerializeField] private Collider _goalCollider; // Reference to the Collider you use for detecting the "goal". Set this in the inspector.
    [SerializeField] private float _displayTime = 2.0f; // Time for how long the "GOAL!" text should be displayed.

    [SerializeField] private ScoreManager _scoreManager;  // Reference to ScoreManager
    [SerializeField] private int _pointsPerScore = 1;      // Points awarded for each score

    // Sound for net swish
    public AudioSource _goalAudioSource;
    public AudioClip _swishClip;

    private void Start()
    {
        if (_goalText)
        {
            _goalText.gameObject.SetActive(false); // Ensure the text is hidden at start.
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Cannonball"))
        {
            ScoreGoal();
            _scoreManager.IncreaseScore(_pointsPerScore);  // Update the score when the projectile hits the goal

            // Play the swish sound effect
            _goalAudioSource.clip = _swishClip;
            _goalAudioSource.Play();
        }
    }

    private void ScoreGoal()
    {
        if (_goalText)
        {
            _goalText.gameObject.SetActive(true);
            _goalText.text = "GOAL!";
            Invoke("HideGoalText", _displayTime); // This will hide the goal text after the specified display time.
        }
    }

    private void HideGoalText()
    {
        if (_goalText)
        {
            _goalText.gameObject.SetActive(false);
        }
    }
}
