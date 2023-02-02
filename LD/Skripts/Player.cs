using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private float _playerSpeed;
    [SerializeField] private float pudding;
    [SerializeField] private int health = 200;
    [SerializeField] private AudioClip DeathSound;
    
    [Header("LaserConf")]
    [SerializeField] private GameObject laser;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private float laserSpeed = 20f;
    [SerializeField] private float fierAwayt = 0.1f;

    private Coroutine FireCorutine;
    private float xMin;
    private float xMax;
    private float yMin;
    private float yMax;
    
    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }


    // Update is called once per frame
    void Update()
    {
        Move();
        Fier();
    }

    private void Fier()
    {
        if (Input.GetButtonDown("Fire1"))
            FireCorutine = StartCoroutine(ToFireAwait());
        if(Input.GetButtonUp("Fire1"))
            StopCoroutine(FireCorutine);
    }

    IEnumerator ToFireAwait()
    {
        while (true)
        {
            GameObject laserMove = Instantiate(laser, transform.position, Quaternion.identity)  as GameObject;
            laserMove.GetComponent<Rigidbody2D>().velocity = new(0, laserSpeed);
            AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position);
            yield return new WaitForSeconds(fierAwayt);   
        }
    }
    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new(0, 0, 0)).x + pudding;
        xMax = gameCamera.ViewportToWorldPoint(new(1,0,0)).x - pudding;
        yMin = gameCamera.ViewportToWorldPoint(new(0, 0, 0)).y + pudding;
        yMax = gameCamera.ViewportToWorldPoint(new(0,1,0)).y - pudding;
    }

    private void Move()
    {
        var deltaXPos = Input.GetAxis("Horizontal") * Time.deltaTime * _playerSpeed;
        var deltaYPos = Input.GetAxis("Vertical")  * Time.deltaTime * _playerSpeed;
        var newYPos = Math.Clamp(transform.position.y + deltaYPos, yMin,yMax);
        var newXPos = Math.Clamp(transform.position.x + deltaXPos, xMin, xMax);
        transform.position = new(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {

        DamageDealer damageDealer = col.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position);
            FindObjectOfType<ScensLoader>().LoadGameOverScene();
            Destroy(gameObject);
        }
        damageDealer.Hit();
    }

    public int GetHealth()
    {
        return health;
    }
}
