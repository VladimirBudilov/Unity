using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Attaker : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 1f;
    [SerializeField] private float damage = 10;
    private GameObject _currentGameObject;
    private void Awake()
    {
        FindObjectOfType<LevelController>().AttackerAppeared();
    }
    private void OnDestroy()
    {
        var levelController = FindObjectOfType<LevelController>();
        if(levelController)
            levelController.AttackerDead();
    }
    private void Update()
    {
        transform.Translate(Vector2.left * walkSpeed * Time.deltaTime);
        IsTargetDead();
    }
    
    private void IsTargetDead()
    {
        if(!_currentGameObject)
            GetComponent<Animator>().SetBool("IsAttack", false);
    }

    public void SetAttackerSpeed(float attackerSpeed) => walkSpeed = attackerSpeed;
    
    public void Attack(GameObject target)
    {
        GetComponent<Animator>().SetBool("IsAttack", true);
        _currentGameObject = target;
    }

    public void StrikeCarrentTarget(float damage)
    {
        if (!_currentGameObject) { return; }
        Health health = _currentGameObject.GetComponent<Health>();
        if (health)
            health.DealDamage(damage);
    }

    public float GetDamage() => damage;
}

