using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScensLoader : MonoBehaviour
{
    public void LoadMainScene()
    {
        StartCoroutine(DelayLoad());
        SceneManager.LoadScene("Main Scene");
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(DelayLoad());
        SceneManager.LoadScene("GameOver Scene");
    }
    
    public void LoadStartScene()
    {
        FindObjectOfType<GameSession>().ResetScore();
        SceneManager.LoadScene("Main Scene");
    }
    
    public void QuitGame() => Application.Quit();

    IEnumerator DelayLoad()
    {
        yield return new WaitForSeconds(1f);
    }
}
