using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        GameObject otherGameObject = col.gameObject;
        if (otherGameObject.GetComponent<Grave>())
            gameObject.GetComponent<Animator>().SetTrigger("IsJumpin");
        else if (otherGameObject.GetComponent<Defender>())
            gameObject.GetComponent<Attaker>().Attack(otherGameObject);
    }
}