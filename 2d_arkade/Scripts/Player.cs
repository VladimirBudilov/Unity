using System;
using System.Collections;
using System.Collections.Generic;
using Mono.Cecil;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 1;

    // [SerializeField] private float playerRadius = 3;
    // [SerializeField] private GameObject weapon;
    [SerializeField] private Camera _camera;
    private Vector3 _mousePos;
    private Animator _animator;
    private float _pudding = 0.37f;
    private float _xMin;
    private float _xMax;
    private float _yMin;
    private float _yMax;

    private void Start()
    {
        SetUpMoveBoundaries();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Move();
        Rotation();
        Attack();
    }

    private void Attack()
    {
        if(Input.GetButtonDown("Fire1"))
            _animator.SetTrigger("Attack");
    }

    private void Move()
    {
        var deltaXPos = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        var deltaYPos = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        var newYPos = Math.Clamp(transform.position.y + deltaYPos, _yMin, _yMax);
        var newXPos = Math.Clamp(transform.position.x + deltaXPos, _xMin, _xMax);
        transform.position = new(newXPos, newYPos, 1);
    }
    private void SetUpMoveBoundaries()
    {
        var gameCamera = Camera.main;
        _xMin = gameCamera.ViewportToWorldPoint(new(0, 0, 0)).x + _pudding;
        _xMax = gameCamera.ViewportToWorldPoint(new(1,0,0)).x - _pudding;
        _yMin = gameCamera.ViewportToWorldPoint(new(0, 0, 0)).y + _pudding;
        _yMax = gameCamera.ViewportToWorldPoint(new(0,1,0)).y - _pudding;
    }
    private void Rotation()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        // using lookat
        // transform.LookAt(target.position, new Vector3(0, 0, -1));
    }

    public Transform GetPlayerPosition()
    {
        return GetComponent<Transform>();
    }
}
