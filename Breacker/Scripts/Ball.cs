using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    [SerializeField] private Puddler puddler;
    [SerializeField] private AudioClip[] ballSounds;
    [SerializeField] private float randomFactor = 0.2f;
    private Rigidbody2D _rigidbody2D;
    private AudioSource _myAudioSource;
    private Vector2 _puddleToBall;
    private bool _hasStarted = false;
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _puddleToBall = transform.position - puddler.transform.position;
        _myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!_hasStarted)
        {
            LockBallToPaddler();
            StartGame();
        }
    }

    private void LockBallToPaddler()
    {
        Vector2 paddlerPos = new(puddler.transform.position.x,
                                puddler.transform.position.y);
        transform.position = _puddleToBall + paddlerPos;
    }

    private void StartGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody2D.velocity = new(1f, 15f);
            _hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        Vector2 velocityTweak = new(Random.Range(0f, randomFactor),
                                    Random.Range(0f, randomFactor));
        if (_hasStarted)
        {
            AudioClip bunce = ballSounds[Random.Range(0, ballSounds.Length)];
            _myAudioSource.PlayOneShot(bunce);
            _rigidbody2D.velocity += velocityTweak;
        }
    }
}
