using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private Slider _loadSlider;
    [SerializeField] private TextMeshProUGUI _loadText;

    // Removed the Start method since we don't want the coroutine to start automatically

    void Update()
    {
        // This is empty and can be removed unless you have plans to add code here later
    }

    public void LoadNextScene()  // This method will be linked to your button
    {
        StartCoroutine("LoadLevel");
    }

    IEnumerator LoadLevel()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Cannon");

        while (!asyncLoad.isDone)
        {
            _loadSlider.value = asyncLoad.progress;
            _loadText.text = (asyncLoad.progress * 100).ToString("0") + "%";  // Display it as a percentage
            yield return null;
        }
    }
}
