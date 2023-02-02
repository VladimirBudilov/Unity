using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : MonoBehaviour
{
    [SerializeField] private int score = 0;
    private int _health;

    private void Awake()
    {
        if (FindObjectsOfType<GameSession>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _health = FindObjectOfType<Player>().GetHealth();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public int GetScore()
    {
        return score;
    }
    
    public void AddScore(int scoreForKilling)
    {
        score += scoreForKilling;
    }

    public void ResetScore()
    {
        Destroy(gameObject);
    }
}
