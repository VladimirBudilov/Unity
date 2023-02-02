using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] private float damage = 10;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var health = col.GetComponent<Health>();
        if (health)
            health.DecreaseLife(damage);
    }

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
