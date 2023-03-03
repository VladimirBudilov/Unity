using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float health = 100f;
    //[SerializeField] private float speed = 10f;

    //[SerializeField] private Animator _animator;
    
    private void StillLive()
    {
        if (health <= 0)
            Destroy(gameObject);
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        StillLive();
    }
}
