using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [SerializeField] private float levelTime = 3;
    [SerializeField] private float timeNow;
    bool triggeredLevelFinished = false;
    
    private void Start()
    {
    }

    private void Update()
    {
        if (triggeredLevelFinished)
        {
            return;
        }

        GetComponent<UnityEngine.UI.Slider>().value = Time.timeSinceLevelLoad / levelTime;

        bool timerFinished = (Time.timeSinceLevelLoad >= levelTime);
        if (timerFinished)
        {
            GlobalEventManager.IsGameOver();
            triggeredLevelFinished = true;
        }
    }

    public void DecreaseLevelTime(float time)
    {
        levelTime -= time;
    }
}
