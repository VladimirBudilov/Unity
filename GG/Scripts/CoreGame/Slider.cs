using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    [Tooltip("timee")] [SerializeField] private float levelTime = 3;
    [SerializeField] private float timeNow;
    bool triggeredLevelFinished = false;

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
            FindObjectOfType<LevelController>().LevelTimerFinished();
            triggeredLevelFinished = true;
        }
    }
}
