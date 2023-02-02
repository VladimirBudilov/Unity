using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    float spawnRate = 2.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    int score;
    public bool gameIsActive;
    public Button restartButton;
    public GameObject titleScreen;

    IEnumerator SpawnTarget() {
        while(gameIsActive) {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);}
    }

    public void ScoreAdd(int addScore){
        score += addScore;
        scoreText.text = "Score : " + score;
    }

    public void StartGame(int difficulty){
        spawnRate /= difficulty;
        titleScreen.gameObject.SetActive(false);
        gameIsActive = true;
        StartCoroutine(SpawnTarget());
        ScoreAdd(0);
    }

    public void GameOver() {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        gameIsActive = false;
    }

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);
}
