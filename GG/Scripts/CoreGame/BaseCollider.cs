using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        var otherObject = col.GetComponent<Attaker>();
        FindObjectOfType<LifeDisplay>().DecreaseLife(otherObject.GetDamage());
        Destroy(col);
    }
}
