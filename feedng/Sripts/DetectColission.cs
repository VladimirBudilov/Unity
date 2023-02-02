using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyoutofBounds : MonoBehaviour
{
    float leftBound = 35.0f;
    float downBound = -15.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -leftBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.y < downBound)
        {
            Destroy(gameObject);
        }

    }
}

