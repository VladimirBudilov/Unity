using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    private const string DEFENDERS_PARENT = "Defendes";
    private GameObject defendersParent;
    private Defender defender;


    private void Start()
    {
        CreateDefendersParent();
    }

    private void OnMouseDown()
    {
        var starDisplay = FindObjectOfType<StarsDisplay>();
        if (starDisplay.HaveEnoughStars(defender.GetCost()))
        {
            var newdefender = Instantiate(defender, GetSpownPos(), Quaternion.identity);
            newdefender.transform.parent = defendersParent.transform;
            defender.SpendStars();
        }
            
    }

    private void CreateDefendersParent()
    {
        defendersParent = GameObject.Find(DEFENDERS_PARENT);
        if (!defendersParent)
            defendersParent = new GameObject(DEFENDERS_PARENT);
    }

    private Vector2 GetSpownPos()
    {
        Vector2 mousePos = new(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.x = Mathf.RoundToInt(worldPos.x);
        worldPos.y = Mathf.RoundToInt(worldPos.y);
        return worldPos;
    }

    public void SetSelectedDefender(Defender newDefender)
    {
        defender = newDefender;
    }
}
