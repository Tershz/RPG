using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    public Slider BGMSlider;
    public Slider SFXSlider;
    public Slider MuteSlider;

    private static float musicVolume = 1f;
    private static float SFXVolume = 1f;

    //Source Audio
    public AudioSource audioSource;
    /*public AudioSource SFXSource1;
    public AudioSource SFXSource2;*/
    
    float volumeValue;
    float SFXValue;

    void Start(){
        if(audioSource == null){
            Debug.LogError(this, this);
        }
        Time.timeScale = 1;
        audioSource.volume = musicVolume;
        /*SFXSource1.volume = SFXVolume;
        SFXSource2.volume = SFXVolume;*/

        BGMSlider.value = musicVolume;
        SFXSlider.value = SFXVolume;
    }

    void Update(){
        
        audioSource.volume = musicVolume;
        /*SFXSource1.volume = SFXVolume;
        SFXSource2.volume = SFXVolume;*/
    }

    public void updateVolume(float volume)
    {
        musicVolume = volume;
        volumeValue = volume;
    }
    public void updateVolumeText(TextMeshProUGUI volumeText)
    {
         volumeValue = volumeValue * 100;
         volumeText.text = ((int)volumeValue).ToString();
    }
    
    public void updateSFX(float SFX)
    {
        SFXVolume = SFX;
        SFXValue = SFX;
    }
    public void updateSFXText(TextMeshProUGUI SFXText)
    {
        SFXValue = SFXValue * 100;
        SFXText.text = ((int)SFXValue).ToString();
    } 
    public void updateMuteText(TextMeshProUGUI MuteText)
    {
        if (MuteSlider.value == 0)
        {
            MuteText.text = "OFF";
        }
        else
        {
            MuteText.text = "ON";
        }
    }

    public void updateAll()
    {
        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
        else
        {
            audioSource.Play();
        }
    }
    
    
}
