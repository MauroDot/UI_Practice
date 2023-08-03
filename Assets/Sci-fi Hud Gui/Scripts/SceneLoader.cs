using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string sceneName; // The name of the scene you want to load.

    public void LoadScene()
    {
        // Load the specified scene when the button is pressed.
        SceneManager.LoadScene(sceneName);
    }
}

