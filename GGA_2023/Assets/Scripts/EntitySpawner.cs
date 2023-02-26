using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EntitySpawner : MonoBehaviour
{
    [SerializeField] private bool spawn = true;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject water;
    [SerializeField] private float minRng = 1;
    [SerializeField] private float maxRng = 3;  
    private int enemySpawnCounter = 0;
    // [SerializeField] private int enemySpawnRegulation = 2;
    private void Awake()
    {
        GlobalEventManager.OnGameTimeOver.AddListener(StopSpawn);
    }
    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minRng, maxRng));
            if (!spawn)
            {
                GlobalEventManager.RealGameOver();
                yield break;
            }
            if (enemySpawnCounter < Random.Range(1,6))
            {
                enemySpawnCounter++;
                StarEnemySpawn();
            }
            else
            {
                StarWaterSpawn();
                enemySpawnCounter = 0;
            }
        }
    }

    private void StopSpawn()
    {
        Debug.Log("spawnstop");
        spawn = false;
    }

    private void StarEnemySpawn()
    {
        var Object = Instantiate(enemy,
            transform.position,
            transform.rotation);
        Object.GetComponent<MoveEntity>().WalkEnemySpeed = GameController.enemySpeed;
        Object.transform.parent = transform;
    }
    private void StarWaterSpawn()
    {
        var Object = Instantiate(water,
            transform.position,
            transform.rotation);
        Object.GetComponent<MoveEntity>().WalkWaterSpeed = GameController.waterSpeed;
        Object.transform.parent = transform;
    }
}