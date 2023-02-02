using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    [Header("Enemy")]
    [SerializeField] private GameObject enemyLaser;
    [SerializeField] private float laserSpeed = 15f;
    [SerializeField] private float health = 200;
    [SerializeField] private GameObject explosion;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] [Range(0,1)] private float volume = 1;
    [SerializeField] private int scoreForEnemy = 100;
 
    [Header("LaserConf")] [SerializeField] private AudioClip shootSound;
    [SerializeField] private float shootDelay;
    [SerializeField] private float minDelay = 0.2f;
    [SerializeField] private float maxDelay = 3f;

    // Start is called before the first frame update
    void Start()
    {
        shootDelay = Random.Range(minDelay, maxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        DelayAndShoot();
    }

    private void DelayAndShoot()
    {
        shootDelay -= Time.deltaTime;
        if (shootDelay <= 0f)
        {
            Fire();
            shootDelay = Random.Range(minDelay, maxDelay);
        }
    }
 
    private void Fire()
    {
        GameObject laser = Instantiate(enemyLaser, transform.position, Quaternion.identity) as GameObject;
        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -laserSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, volume);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        DamageDealer damageDealer = col.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            var deathExplosion = Instantiate(explosion, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(deathSound, Camera.main.transform.position);
            FindObjectOfType<GameSession>().AddScore(scoreForEnemy);
            Destroy(gameObject);
            Destroy(deathExplosion, 0.5f);
        }
        damageDealer.Hit();
    }
}
