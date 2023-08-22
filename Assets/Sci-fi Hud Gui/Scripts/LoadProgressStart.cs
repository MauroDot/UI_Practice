using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadProgressStart : MonoBehaviour
{
    [SerializeField] private GameObject _loadPanel;  // Reference to the panel containing the slider and text
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private TextMeshProUGUI _loadText;

    public void LoadNextScene()  // This method will be linked to your button
    {
        _loadPanel.SetActive(true);  // Show the panel, slider, and text
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Start");

        asyncLoad.allowSceneActivation = false;  // This prevents the scene from switching immediately when loading is done

        float timer = 0;
        const float minimumLoadTime = 3.0f;  // Minimum time in seconds that the loading bar will be visible

        while (asyncLoad.progress < 0.9f || timer < minimumLoadTime)
        {
            _loadSlider.value = asyncLoad.progress;
            _loadText.text = (asyncLoad.progress * 100).ToString("F0") + "%";

            Debug.Log("Loading progress: " + asyncLoad.progress);  // Debug line

            timer += Time.deltaTime;
            yield return null;
        }

        _loadSlider.value = 1;
        _loadText.text = "100%";

        asyncLoad.allowSceneActivation = true;
    }
}
