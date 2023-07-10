using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public string scenePath; // The path to the scene you want to load
    public float delayInSeconds = 5f; // The delay in seconds before loading the scene

    private void Start()
    {
        StartCoroutine(LoadSceneAfterDelay());
    }

    private IEnumerator LoadSceneAfterDelay()
    {
        yield return new WaitForSeconds(delayInSeconds);
        SceneManager.LoadScene(scenePath);
    }
}

