using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float inputController;
    float speed = 10.0f;
    float xRange = 15;
    public GameObject projectivePrifab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ( transform.position.x < -xRange)
        {
            transform.position = new Vector3 (-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectivePrifab, transform.position, projectivePrifab.transform.rotation);
        }
        inputController = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * inputController * Time.deltaTime * speed);
        
    }
}
