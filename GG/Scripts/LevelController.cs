using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int attackerAmount = 0;
    [SerializeField] private bool lvlTimerIsOver = false;
    [SerializeField] private GameObject winCanvas;
    [SerializeField] private GameObject loseCanvas;
    [SerializeField] private float sceneTime;
    [SerializeField] private LifeDisplay lifeDisplay;

    private void Start()
    {
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
    }

    private void OnEnable()
    {
        lifeDisplay.LifeChanged += OnLifeChanged;
    }

    private void OnDisable()
    {
        lifeDisplay.LifeChanged -= OnLifeChanged;
    }

    private void Update()
    {
        sceneTime = Time.timeScale;
    }

    public void AttackerAppeared() => attackerAmount++;

    public void AttackerDead()
    {
        attackerAmount--;
        if (lvlTimerIsOver && (attackerAmount <= 0))
        {
            Debug.Log("lvl complite) Spawn will be stop, will be start winner canvas");
            StartCoroutine(WinCanvasPlay());
        }
    }

    IEnumerator WinCanvasPlay()
    {
        winCanvas.SetActive(true);
        yield return new WaitForSeconds(5);
        FindObjectOfType<ScensLoader>().LoadNextScene();
    }

    public void LevelTimerFinished()
    {
        lvlTimerIsOver = true;
        StopSpawning();
    }

    private static void StopSpawning()
    {
        var spawnerArray = FindObjectsOfType<AttackSpowner>();
        foreach (var spawner in spawnerArray)
        {
            spawner.StopSpawn();
        }
    }

    private void LoseCanvasPlay()
    {
        loseCanvas.SetActive(true);
        Debug.Log($"timeScale was {Time.timeScale.ToString()}");
        Time.timeScale = 0;
        Debug.Log($"timeScale now {Time.timeScale.ToString()}");
    }

    private void OnLifeChanged(float life)
    {
        if (life <= 0)
            LoseCanvasPlay();
    }
}