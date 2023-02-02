using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float objectHealth = 100;

    public float ObjectHealth
    {
        get => objectHealth;
        set => objectHealth = value;
    }
    
    public void DecreaseLife(float damage)
    {
        if(damage > 0)
            objectHealth -= damage;
        if(ObjectHealth <= 0)
        {
            Destroy(gameObject);
            if (GetComponent<Enemy>())
                FindObjectOfType<AttackSpawn>().EnemyCounter--;
        }
    }
}
