using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private Canvas pauseMenuCanvas;

    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenuCanvas.gameObject.SetActive(isPaused);

        // If you want to actually pause game logic when the menu is active:
        if (isPaused)
        {
            Time.timeScale = 0;  // Pause the game
        }
        else
        {
            Time.timeScale = 1;  // Resume the game
        }
    }
}
