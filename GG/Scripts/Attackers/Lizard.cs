using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject otherGameObject = col.gameObject;
        if (otherGameObject.GetComponent<Defender>())
            gameObject.GetComponent<Attaker>().Attack(otherGameObject);
    }
}
