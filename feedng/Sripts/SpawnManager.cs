using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefabs;
    float spownPosZ = 20;
    float spownRangeX = 20;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(SpownRandomAnimal), 2, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void SpownRandomAnimal()
    {
    
        int animalIndex = Random.Range(0, animalPrefabs.Length);
        Vector3 spownPos = new Vector3(Random.Range(-spownRangeX, spownRangeX), 0, spownPosZ);

        Instantiate(
            animalPrefabs[animalIndex],
            spownPos,
            animalPrefabs[animalIndex].transform.rotation);

    }
}
