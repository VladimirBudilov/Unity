using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEntity : MonoBehaviour
{
    public float WalkEnemySpeed { get; set; } = GameController.enemySpeed;
    public float WalkWaterSpeed { get; set; } = GameController.waterSpeed;
    [SerializeField] private float speedDecreasing = 3;
    [SerializeField] private float lvlTimeIncrease = 10;
    

    private void Update()
    {
        EnemyMove();
    }

    private void EnemyMove()
    {
        transform.Translate(Vector2.up * WalkEnemySpeed * Time.deltaTime);
    }
    private void WaterMove()
    {
        transform.Translate(Vector2.up * WalkWaterSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.CompareTag("water") && other.CompareTag("Player"))
        {
            GlobalEventManager.SlowGame(-speedDecreasing);
            FindObjectOfType<Slider>().DecreaseLevelTime(-lvlTimeIncrease);
        }
        else if (gameObject.CompareTag("rock") && other.CompareTag("Player"))
        {
            FindObjectOfType<Slider>().DecreaseLevelTime(lvlTimeIncrease);
            GlobalEventManager.SlowGame(speedDecreasing);
        }
        Destroy(gameObject);
    }
}
