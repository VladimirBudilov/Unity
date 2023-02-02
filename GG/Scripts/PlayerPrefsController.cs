using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string VOLUME_KEY = "volume";
    const string DIFFICULTY_KEY = "diffculty";
    const float VOLUME_MIN = 0;
    const float VOLUME_MAX = 1;
    const float DIFFICULTY_MIN = 0;
    const float DIFFICULTY_MAX = 90;

    public static void SetVolume(float volume)
    {
        if(volume >= VOLUME_MIN && volume <= VOLUME_MAX)
            PlayerPrefs.SetFloat(VOLUME_KEY, volume);
    }

    public static float GetVolume()
    {
        return PlayerPrefs.GetFloat(VOLUME_KEY);
    }
    
    public static void SetDiffculty(float diffculty)
    {
        if(diffculty >= DIFFICULTY_MIN && diffculty <= DIFFICULTY_MAX)
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, diffculty);
    }

    public static float GetDiffculty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
