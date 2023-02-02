using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StarsDisplay : MonoBehaviour
{
    [SerializeField] private float stars = 1000;
    private TextMeshProUGUI startText;
    void Start()
    {
        startText = GetComponent<TextMeshProUGUI>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        startText.text = stars.ToString();
    }

    public void AddStars(float amount)
    {
        stars += amount;
        UpdateDisplay();
    }
    
    public void SpendingStars(float amount)
    {
        if(stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();
        }
    }

    public bool HaveEnoughStars(float amount)
    {
        return stars >= amount;
    }
}
