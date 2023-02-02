using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] private Defender defenderPrefab;
    private TextMeshProUGUI text;

    
    
    private void Start()
    {
        LabelStartCost();
    }
    
    private void LabelStartCost()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        if (text)
            text.text = defenderPrefab.GetCost().ToString();
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach(DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(41, 41, 41, 255);
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        FindObjectOfType<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
