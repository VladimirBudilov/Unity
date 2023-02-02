using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScensLoader : MonoBehaviour
{
    private int awaitTime = 3;
    private int sceneIndex;
    
    void Start()
    {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (sceneIndex == 0)
            StartCoroutine(Loading());
    }

    IEnumerator Loading()
    {
        yield return new WaitForSeconds(awaitTime);
        LoadNextScene();
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneIndex + 1);
    }

    public void LoadGameScene()
    {
        Debug.Log("restart");
        Time.timeScale = 1;
        Debug.Log($" time scale after restart {Time.timeScale.ToString()}");
        SceneManager.LoadScene("Game Scene");
    }
    public void LoadStartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Scee");
    }

    public void LoadOtionsScene()
    {
        SceneManager.LoadScene("Options Scene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
