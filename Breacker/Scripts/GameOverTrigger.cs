using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        SceneManager.LoadScene("End of Game");
    }
}
