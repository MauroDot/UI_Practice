using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;
using static GameManager;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField _profileNameInput;

    public void CreateProfile()
    {
        // Validation and profile creation logic here...
        string profileName = _profileNameInput.text;

        if (!string.IsNullOrEmpty(profileName))
        {
            //PlayerData.CreateProfile(profileName);
            // Optionally, transition to the game scene after profile creation
            StartGame();
        }
        else
        {
            Debug.LogWarning("Profile name cannot be empty!");
        }
    }

    public void StartGame()
    {
        // Transition to the game scene
        SceneManager.LoadScene("GameScene"); // Assuming your game scene is named "GameScene"
    }

    public void ViewStats()
    {
        // Transition to the stats scene
        SceneManager.LoadScene("StatsScene"); // Assuming your stats scene is named "StatsScene"
    }
}
