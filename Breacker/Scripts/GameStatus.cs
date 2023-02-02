using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
  [Range(0.1f, 10f)] [SerializeField] private float gameSpeed = 1f;
  [SerializeField] private int currentScore = 0;
  [SerializeField] private int pointsPerBrockenBock = 83;
  [SerializeField] private TextMeshProUGUI score;
  [SerializeField] private bool isAutoplayEnabled;

  private void Awake()
  {
    var gameStatusCounter = FindObjectsOfType<GameStatus>().Length;
    if (gameStatusCounter > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
      DontDestroyOnLoad(gameObject);
  }

  private void Update()
  {
    Time.timeScale = gameSpeed;
    score.text = currentScore.ToString();
  }

  public void AddScore()
  {
    currentScore += pointsPerBrockenBock;
  }

  public void ResetScore()
  {
    Destroy(gameObject);
  }

  public bool IsAutoplayEnabled()
  {
    return isAutoplayEnabled;
  }
}
