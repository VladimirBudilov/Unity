using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AttackSpowner : MonoBehaviour
{
    [SerializeField] private bool spown = true;
    [SerializeField] private Attaker[] attackerPrefab;
    private LevelController _levelController;
    IEnumerator Start()
    {
        while (spown)
        {
            yield return new WaitForSeconds(Random.Range(5f, 7f));
            StartSpown();
        }
    }

    public void StopSpawn()
    {
        spown = false;
    }

    private void StartSpown()
    {
        Attaker newAttacker = Instantiate(attackerPrefab[Random.Range(0, attackerPrefab.Length)], transform.position, transform.rotation);
        newAttacker.transform.parent = transform;
    }

}
