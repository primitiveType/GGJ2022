using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScript : MonoBehaviour
{

    public AudioMixer volume;
    public bool isFullScreen = false;

    [SerializeField]
    private Slider volumeSlider = null;



    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("volume", volumeValue);
        
    }

    public void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
    
    public void SetFullscreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
   
   
}
