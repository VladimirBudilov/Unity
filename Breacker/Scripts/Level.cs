using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private int destroyBlockCounter;
    private SceanLoader _sceanLoader;
    public void CountBreakableBlocks() => destroyBlockCounter++;

    private void Start()
    {
        _sceanLoader = FindObjectOfType<SceanLoader>();
    }
    
    public void BlockDestoed()
    {
        destroyBlockCounter--;
        if (destroyBlockCounter <= 0)
            _sceanLoader.LoadNextScene();
    }
}
