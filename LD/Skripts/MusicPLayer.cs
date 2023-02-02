using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPLayer : MonoBehaviour
{
    private void Awake()
    {
        var amountOfMusicPlayers = FindObjectsOfType<AudioSource>().Length;
        if(amountOfMusicPlayers > 1)
            Destroy(gameObject);
        else
            DontDestroyOnLoad(gameObject);
    }
}
