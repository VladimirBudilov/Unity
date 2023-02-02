using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    private WaveConf _waveConf;
    private List<Transform> wayPoints;
    private float enemySpeed;
    private int waypointIndex = 0;


    private void Start()
    {
        wayPoints = _waveConf.GetWayPoints();
        transform.position = wayPoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConf(WaveConf waveConf)
    {
        _waveConf = waveConf;
    }
    private void Move()
    {
        if (waypointIndex < wayPoints.Count)
        {
            var targetPosition = wayPoints[waypointIndex].transform.position;
            var moveThisFrame = _waveConf.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveThisFrame);
            if (transform.position == targetPosition)
                waypointIndex++;
        }
        else
            Destroy(gameObject);
    }
}
