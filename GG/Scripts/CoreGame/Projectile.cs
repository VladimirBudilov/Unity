using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float damage = 200;
    [SerializeField] private Vector3 angle;
    
    
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //_rigidbody.AddTorque(30 * Time.deltaTime * speed);
        _rigidbody.velocity = new(speed, 0);
        _rigidbody.MoveRotation(Quaternion.Euler(transform.rotation.eulerAngles + angle));
    }
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        var attacker = col.GetComponent<Attaker>();
        var health = col.GetComponent<Health>();
        if(attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }
    }
}
