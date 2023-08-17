using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadProgressStart : MonoBehaviour
{
    [SerializeField] private GameObject loadPanel;  // Reference to the panel containing the slider and text
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private TextMeshProUGUI _loadText;

    public void LoadNextScene()  // This method will be linked to your button
    {
        loadPanel.SetActive(true);  // Show the panel, slider, and text
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Start");

        while (!asyncLoad.isDone)
        {
            _loadSlider.value = asyncLoad.progress;
            _loadText.text = (asyncLoad.progress * 100).ToString("Loading");  // Display it as a percentage
            yield return null;
        }
    }
}
