using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class DifficultyDropdownHandler : MonoBehaviour
{
    public TMP_Dropdown _difficultyDropdown;  // Reference to your TMP Dropdown component.
    public TMP_Text _selectedDifficultyText;   // Reference to your TMP Text component for displaying the chosen difficulty.

    public int PlayerDamage { get; private set; } // Exposing it as a property for other scripts to access if needed.

    private enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }

    private Dictionary<Difficulty, int> _damageValues = new Dictionary<Difficulty, int>
    {
        { Difficulty.Easy, 1 },
        { Difficulty.Medium, 3 },
        { Difficulty.Hard, 6 }
    };

    private void Start()
    {
        if (_difficultyDropdown == null || _selectedDifficultyText == null)
        {
            Debug.LogError("Ensure all references are set in the DifficultyDropdownHandler script.");
            return;
        }

        // Set the dropdown's onValueChanged event.
        _difficultyDropdown.onValueChanged.AddListener(OnDropdownValueChanged);

        // Set the initial damage value based on the dropdown value.
        OnDropdownValueChanged(_difficultyDropdown.value);
    }

    private void OnDropdownValueChanged(int selectedIndex)
    {
        Difficulty selectedDifficulty = (Difficulty)selectedIndex;
        PlayerDamage = _damageValues[selectedDifficulty];
        _selectedDifficultyText.text = $"{_difficultyDropdown.options[selectedIndex].text} (Damage: {PlayerDamage})";
    }
}
