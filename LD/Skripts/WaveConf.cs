using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
[CreateAssetMenu(menuName = "Enemy Way Config")]
public class WaveConf : ScriptableObject
{
   [SerializeField] private GameObject enemyPrefab;
   [SerializeField] private GameObject pathPrefab;
   [SerializeField] private float timeBetweenSpawn = 1f;
   [SerializeField] private float randomFactor = 0.3f;
   [SerializeField] private int numberOfEnemys = 8;
   [SerializeField] private float moveSpeed =2f;

   public GameObject GetEnemyPrefab() { return enemyPrefab; }

   public List<Transform> GetWayPoints()
   {
      return pathPrefab.transform.Cast<Transform>().ToList();
   }
   public float GetTimeBetweenSpawn() { return timeBetweenSpawn; }
   public int GetNumberOfEnemys() { return numberOfEnemys; }
   public float GetRandomFactor() { return randomFactor; }
   public float GetMoveSpeed() { return moveSpeed; }
}
