using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour
{
    [SerializeField] private UnityEngine.UI.Slider _sliderVolume;
    [SerializeField] private UnityEngine.UI.Slider _sliderDifficulty;
    [SerializeField] private float defaultVolume = 0.7f;
    [SerializeField] private float defaultDifficulty = 60f;
    

    void Start()
    {
        _sliderVolume.value = PlayerPrefsController.GetVolume();
        _sliderDifficulty.value = PlayerPrefsController.GetDiffculty();
    }   
    
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if(musicPlayer)
            musicPlayer.SetVolume(_sliderVolume.value);
    }
    public void SaveAndExit()
    {
        PlayerPrefsController.SetVolume(_sliderVolume.value);
        PlayerPrefsController.SetDiffculty(_sliderDifficulty.value);
        FindObjectOfType<ScensLoader>().LoadStartScene();
    }

    public void SetDefaults()
    {
        _sliderVolume.value = defaultVolume;
        _sliderDifficulty.value = defaultDifficulty;
    }
}
