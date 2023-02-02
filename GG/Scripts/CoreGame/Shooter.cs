using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject gun;
    private AttackSpowner _myLaneSpawner;
    private Animator _animator;
    private const string PROJECTILES_PARENT = "Projectiles";
    private GameObject projectilesParent;

    private void Start()
    {
        SetLaneSpawner();
        _animator = GetComponent<Animator>();
        CreateDefendersParent();
    }

    private void Update()
    {
        if(IsAttackerInLane())
            _animator.SetBool("IsFire", true);
        else
            _animator.SetBool("IsFire", false);
    }
    private void CreateDefendersParent()
    {
        projectilesParent = GameObject.Find(PROJECTILES_PARENT);
        if (!projectilesParent)
            projectilesParent = new GameObject(PROJECTILES_PARENT);
    }
    private bool IsAttackerInLane()
    {
        if(_myLaneSpawner.transform.childCount <= 0)
            return false;
        else
            return true;
        }
    
    public void Fire()
    {
        var newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation);
        newProjectile.transform.parent = projectilesParent.transform;
    }
    
    private void SetLaneSpawner()
    {
        var laneSpawner = FindObjectsOfType<AttackSpowner>();
        foreach (var spawner in laneSpawner)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (IsCloseEnough)
                _myLaneSpawner = spawner;
        }
    }
}
