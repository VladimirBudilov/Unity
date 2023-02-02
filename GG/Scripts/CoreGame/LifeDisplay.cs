using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LifeDisplay : MonoBehaviour
{
    
    [SerializeField] private float baseLife = 100;
    private TextMeshProUGUI startText;
    private ScensLoader _scensLoader;
    private float life;

    public event Action<float> LifeChanged;

    private void Start()
    {
        life = baseLife - PlayerPrefsController.GetDiffculty();
        _scensLoader = FindObjectOfType<ScensLoader>();
        startText = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        startText.text = life.ToString();
    }

    public void DecreaseLife(float damage)
    {
        life -= damage;
        LifeChanged?.Invoke(life);
    }
}
