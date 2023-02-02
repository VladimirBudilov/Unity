using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] private float scrollingSpeed = 0.3f;

    private Material _material;
    private Vector2 _offSet;
    // Start is called before the first frame update
    void Start()
    {
        _material = GetComponent<Renderer>().material;
        _offSet = new(0,scrollingSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        _material.mainTextureOffset += _offSet * Time.deltaTime;
    }
}
