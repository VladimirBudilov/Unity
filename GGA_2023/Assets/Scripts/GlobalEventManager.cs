using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static readonly UnityEvent OnGameTimeOver = new UnityEvent();
    public static readonly UnityEvent<float> OnSlow = new UnityEvent<float>();
    public static readonly UnityEvent OnRealGameOver = new UnityEvent();

    public static void SlowGame(float speed)
    {
        OnSlow?.Invoke(speed);
    }
    public static void IsGameOver()
    {
        OnGameTimeOver?.Invoke();
    }

    public static void RealGameOver()
    {
        OnRealGameOver?.Invoke();
    }
}
