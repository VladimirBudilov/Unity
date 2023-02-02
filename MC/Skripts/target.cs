using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class target : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem particleExplosion;
    public int scoreVolume;
    
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(14, 18), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10));
        transform.position = new Vector3(Random.Range(-5, 5), -6);
    }
    private void OnMouseDown(){
        while (gameManager.gameIsActive){
            Instantiate(particleExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
            gameManager.ScoreAdd(scoreVolume);
        }
    }
    private void OnTriggerEnter(Collider other){
        Destroy(gameObject);
        if(!gameManager.CompareTag("Bad"))
            gameManager.GameOver();
    }
}



