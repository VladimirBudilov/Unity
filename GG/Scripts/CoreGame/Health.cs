using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float HealthOfUnit
    {
        get => _health;
        private set => _health = value;
    }

    [SerializeField] private GameObject _particle;
    [SerializeField] private float _health = 100;

    public void DealDamage(float damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            var _particleActive = Instantiate(_particle, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(_particleActive, 0.5f);
        }
    }
}
