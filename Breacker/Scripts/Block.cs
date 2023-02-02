using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private GameStatus _gameStatus;
    [SerializeField] private GameObject particles;
    [SerializeField] private int hitsCounter;
    [SerializeField] private Sprite[] hitSprites;
    private Level _level;

    private void Start()
    {
        _level = FindObjectOfType<Level>();
        if(CompareTag("Breacable"))
            _level.CountBreakableBlocks();
        _gameStatus = FindObjectOfType<GameStatus>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (CompareTag("Breacable"))
        {
            hitsCounter++;
            if(hitsCounter >= hitSprites.Length + 1)
                DestroyBlock();
            else
            {
                int spriteIndex = hitsCounter - 1;
                GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
            }
        }
    }

    private void DestroyBlock()
    {
        _level.BlockDestoed();
        AudioSource.PlayClipAtPoint(_destroySound, Camera.main.transform.position);
        Destroy(gameObject, 0.1f);
        _gameStatus.AddScore();
        InstantiateParticles();
    }

    public void InstantiateParticles()
    {
        GameObject sparkles = Instantiate(particles, transform.position, transform.rotation);
        Destroy(sparkles, 2f);
    }
}
