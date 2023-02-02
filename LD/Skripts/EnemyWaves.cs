using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    [SerializeField] private List<WaveConf> _waveConfs;
    [SerializeField] private int startingIndex = 0;
    [SerializeField] private bool looping = true;

    private int waveIndex;
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int i = startingIndex; i < _waveConfs.Count; i++)
        {
            var currentWave = _waveConfs[i];
            yield return StartCoroutine(CurrentWave(currentWave));
        }
    }
    IEnumerator CurrentWave(WaveConf waveConf)
    {
        for (int i = 0; i < waveConf.GetNumberOfEnemys(); i++)
        {
            var newEnemy = Instantiate(waveConf.GetEnemyPrefab(),
                waveConf.GetWayPoints()[0].transform.position,
                Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWaveConf(waveConf);
            yield return new WaitForSeconds(waveConf.GetTimeBetweenSpawn());   
        }
    }
}