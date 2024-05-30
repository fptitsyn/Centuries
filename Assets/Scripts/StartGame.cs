using System;
using UnityEngine;
using UnityEngine.Audio;

public class StartGame : MonoBehaviour
{
    [SerializeField] private AudioMixer mixer;
    
    private void Start()
    {
        if (PlayerPrefs.HasKey(NameHelper.MusicVolume))
        {
            mixer.SetFloat("Music Volume", Mathf.Log10(PlayerPrefs.GetFloat(NameHelper.MusicVolume)) * 20);
        }
            
        if (PlayerPrefs.HasKey(NameHelper.SoundVolume))
        {
            mixer.SetFloat("Sound Volume", Mathf.Log10(PlayerPrefs.GetFloat(NameHelper.SoundVolume)) * 20);
        }
    }
}
