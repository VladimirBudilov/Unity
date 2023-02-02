using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Defender : MonoBehaviour
{
   [SerializeField] private float cost = 100;
   private StarsDisplay _starsDisplay;
   
   public float GetCost()
   {
      return cost;
   }

   public void AddStars(int amount)
   {
      FindObjectOfType<StarsDisplay>().AddStars(amount);
   }

   public void SpendStars()
   { 
      FindObjectOfType<StarsDisplay>().SpendingStars(cost);      
   }
}
