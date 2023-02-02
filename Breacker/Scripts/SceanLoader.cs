using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceanLoader : MonoBehaviour
{
    private GameStatus _gameStatus;
    private void Start()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    public void LoadNextScene()
    {
        int carrentSceneindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(carrentSceneindex + 1);
    }

    public void LoadFirstScene()
    {
        SceneManager.LoadScene(0);
        _gameStatus.ResetScore();
    } 

    public void QuitGame() => Application.Quit();
}
