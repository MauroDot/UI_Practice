using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using System.Linq;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager Instance;

    [Header("UI Components")]
    [SerializeField] private TMP_InputField _profileInputField;
    [SerializeField] private TMP_Dropdown _profileDropdown;
    [SerializeField] private TMP_Text _creationMessageText;
    [SerializeField] private TMP_Text _statsText;
    [SerializeField] private TMP_Text _allStatsText;  // To display all profiles' stats

    private string _currentProfileName;
    private int _currentProfileScore;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        LoadProfilesIntoDropdown();
    }
    public void CreateProfile()
    {
        string playerName = _profileInputField.text;
        if (string.IsNullOrEmpty(playerName)) return;

        // Save the player's profile
        List<string> profiles = GetProfilesList();
        if (!profiles.Contains(playerName))
        {
            profiles.Add(playerName);
            PlayerPrefs.SetString("profiles", string.Join(";", profiles));
        }

        StartCoroutine(ShowCreationMessage());

        // Reload the dropdown
        LoadProfilesIntoDropdown();

        Debug.Log($"Created and saved profile: {playerName}");
    }
    private List<string> GetProfilesList()
    {
        return new List<string>(PlayerPrefs.GetString("profiles", "").Split(';').Where(profile => !string.IsNullOrEmpty(profile)));
    }
    private IEnumerator ShowCreationMessage()
    {
        _creationMessageText.text = "Profile Created!";
        yield return new WaitForSeconds(3);  // Message stays for 3 seconds
        _creationMessageText.text = "";
    }
    public void LoadProfilesIntoDropdown()
    {
        _profileDropdown.ClearOptions();
        string[] profiles = PlayerPrefs.GetString("profiles", "").Split(';');
        _profileDropdown.AddOptions(new List<string>(profiles));
    }
    public void SelectProfileFromDropdown()
    {
        _currentProfileName = _profileDropdown.options[_profileDropdown.value].text;
        Debug.Log($"Selected profile: {_currentProfileName}");
        _currentProfileScore = PlayerPrefs.GetInt(_currentProfileName, 0);

        UpdateStatsText();
    }
    public void AddScoreToCurrentProfile(int scoreToAdd)
    {
        Debug.Log($"Adding {scoreToAdd} points to profile: {_currentProfileName}");

        if (!string.IsNullOrEmpty(_currentProfileName))
        {
            _currentProfileScore += scoreToAdd;
            SaveProfile();
        }
    }
    private void SaveProfile()
    {
        if (!string.IsNullOrEmpty(_currentProfileName))
        {
            PlayerPrefs.SetInt(_currentProfileName, _currentProfileScore);
        }
    }
    public void UpdateStatsText()
    {
        // Update statsText to only show total points
        _statsText.text = $"Total Points: {_currentProfileScore}";
    }
    public void ClearProfiles()
    {
        PlayerPrefs.DeleteAll();
        _profileDropdown.ClearOptions();
        PlayerPrefs.SetString("profiles", " ");
    }
    public void ClearStatsForAllProfiles()
    {
        List<string> profiles = GetProfilesList();

        foreach (string profile in profiles)
        {
            // Clear total score for each profile
            PlayerPrefs.SetInt(profile, 0);
            // Clear individual game scores (if they exist in your implementation)
            PlayerPrefs.SetInt(profile + "_math", 0);
            PlayerPrefs.SetInt(profile + "_memory", 0);
        }

        // If the current profile's stats are displayed, update the display
        if (!string.IsNullOrEmpty(_currentProfileName))
        {
            UpdateStatsText();
        }
    }
    public void DisplayAllProfileStats()
    {
        List<string> profiles = GetProfilesList();
        string allStats = "All Player Stats:\n\n";

        foreach (string profile in profiles)
        {
            if (!string.IsNullOrEmpty(profile))  // Additional check, though it should be unnecessary with the LINQ filtering
            {
                int totalScore = PlayerPrefs.GetInt(profile, 0);
                allStats += $"Profile: {profile}\nTotal Points: {totalScore}\n\n";
            }
        }

        _allStatsText.text = allStats;
    }
}

