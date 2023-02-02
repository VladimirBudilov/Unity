using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using UnityEngine;

public class Puddler : MonoBehaviour
{
    [SerializeField]private float minX = 1.5f;
    [SerializeField]private float maxX = 12f;
    
    [SerializeField] private int width = 13;

    private GameStatus _gameStatus;

    private Ball _ball;
    // Start is called before the first frame update
    void Start()
    {
        _gameStatus = FindObjectOfType<GameStatus>();
        _ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Math.Clamp(XPos(), minX, maxX);
        transform.position = paddlePos;
    }

    private float XPos()
    {
        if (_gameStatus.IsAutoplayEnabled())
            return _ball.transform.position.x;
        else
            return Input.mousePosition.x / Screen.width * width;
    }
}
