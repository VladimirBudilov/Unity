using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] public static float waterSpeed = 6f;
    [SerializeField] public static float enemySpeed = 15f;

    private void Start()
    {
        waterSpeed = 6f;
        enemySpeed = 15f;
    }

    private void Awake()
    {
        GlobalEventManager.OnSlow.AddListener(DecreaseSpeed);
    }

    private void Update()
    {
        
    }

    private static void DecreaseSpeed(float speed)
    {
        if (enemySpeed > speed)
        {
            Debug.Log($"speed was {enemySpeed.ToString()}");
            enemySpeed -= speed;
            waterSpeed -= speed;
            foreach (var VARIABLE in FindObjectsOfType<MoveEntity>())
            {
                VARIABLE.WalkEnemySpeed -= speed;
            }
            foreach (var VARIABLE in FindObjectsOfType<MoveEntity>())
            {
                VARIABLE.WalkWaterSpeed -= speed;
            }
            Debug.Log($"speed now {enemySpeed.ToString()}");
        }
        else
        {
            Debug.Log("game over mast be");
            enemySpeed = 0;
            waterSpeed = 0;
            foreach (var VARIABLE in FindObjectsOfType<MoveEntity>())
            {
                VARIABLE.WalkEnemySpeed = 0;
            }
            foreach (var VAR in FindObjectsOfType<MoveEntity>())
            {
                VAR.WalkWaterSpeed = 0;
            }
            GlobalEventManager.RealGameOver();
        }
    }
}
