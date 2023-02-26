using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10;
    // [SerializeField] private Camera _camera;

    private const float _puding = 0.37f;
    private float _xMin;
    private float _xMax;

    private void Start()
    {
        SetUpMoveBoundaries();
    }

    private void Update()
    {
        Move();
    }


    private void Move()
    {
        var deltaXPos = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var newXPos = Math.Clamp(transform.position.x + deltaXPos, _xMin, _xMax);
        transform.position = new(newXPos, transform.position.y, 1);
    }

    private void SetUpMoveBoundaries()
    {
        var gameCamera = Camera.main;
        _xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + _puding;
        _xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - _puding;
    }

    /*private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("collision");
        Destroy(col.GetComponent<GameObject>().gameObject);
        /*if (col.GetComponent<GameObject>().CompareTag("water"))
       
    #1#
    }*/
}