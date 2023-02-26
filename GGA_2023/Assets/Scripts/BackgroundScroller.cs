using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollingSpeed = 0.3f;

    private Material _material;
    private Vector2 _offSet;
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offSet = new(0,scrollingSpeed);
    }

    void Update()
    {
        _material.mainTextureOffset += _offSet * Time.deltaTime;
    }
}
