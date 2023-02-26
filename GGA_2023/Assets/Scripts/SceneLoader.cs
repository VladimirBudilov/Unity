using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private GameObject loseText;
    [SerializeField] private GameObject root;
    [SerializeField] private GameObject water;
    [SerializeField] private GameObject rock;
    
    
    private void Awake()
    {
        GlobalEventManager.OnRealGameOver.AddListener(LoadGameOverScene);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void LoadGameOverScene()
    {
        Debug.Log("gameover corutine starts");
        StartCoroutine(ShowGameOverText());
        Debug.Log("gameover corutine finished");
    }

    public void LoadStartScene()
    {
        GameController.waterSpeed = 5;
        GameController.enemySpeed = 12;
        water.GetComponent<MoveEntity>().WalkWaterSpeed = 5;
        rock.GetComponent<MoveEntity>().WalkEnemySpeed = 12;
        SceneManager.LoadScene("StartScene");
    }

    private IEnumerator ShowGameOverText()
    {
        Debug.Log("yield start");
        loseText.SetActive(true);
        root.SetActive(false);
        GlobalEventManager.IsGameOver();
        yield return new WaitForSeconds(5);
        Debug.Log("yield finished");
        SceneManager.LoadScene("GameOverScene");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

