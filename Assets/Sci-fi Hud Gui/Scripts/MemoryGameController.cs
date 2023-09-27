using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MemoryGameController : MonoBehaviour
{
    public DropPosition[] imageDrops;
    public TextMeshProUGUI timerText;
    public float gameDuration = 30f;
    private float timeRemaining;
    public bool gameStarted = false;
    public Button playButton;
    public Button restartButton;

    void Start()
    {
        timeRemaining = gameDuration;
        foreach (var drop in imageDrops)
        {
            drop.gameObject.SetActive(false); // hide ImageDrops initially
        }
    }

    /*void Update()
    {
        if (gameStarted)
        {
            timeRemaining -= Time.deltaTime;
            timerText.text = Mathf.CeilToInt(timeRemaining).ToString();

            if (AllImagesMatched())
            {
                gameStarted = false;
            }
        }
    }*/

    public void StartGame()
    {
        gameStarted = true;
        playButton.gameObject.SetActive(false);
        foreach (var drop in imageDrops)
        {
            drop.gameObject.SetActive(true); // show ImageDrops
        }
    }

    /*bool AllImagesMatched()
    {
        foreach (var drop in imageDrops)
        {
            if (!drop.IsCorrectMatch())
            {
                return false;
            }
        }
        return true;
    }*/

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
