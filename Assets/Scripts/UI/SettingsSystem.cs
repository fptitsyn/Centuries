using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI
{
    public class SettingsSystem : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider soundSlider;

        private void Start()
        {
            if (PlayerPrefs.HasKey(NameHelper.MusicVolume))
            {
                musicSlider.value = PlayerPrefs.GetFloat(NameHelper.MusicVolume);
                SetVolume(NameHelper.MusicVolume);
            }
            
            if (PlayerPrefs.HasKey(NameHelper.SoundVolume))
            {
                soundSlider.value = PlayerPrefs.GetFloat(NameHelper.SoundVolume);
                SetVolume(NameHelper.SoundVolume);
            }
        }

        public void SetVolume(string type)
        {
            float volume;
            
            switch (type)
            {
                case NameHelper.MusicVolume:
                    volume = musicSlider.value;
                    break;
                case NameHelper.SoundVolume:
                    volume = soundSlider.value;
                    break;
                default:
                    return;
            }
            
            mixer.SetFloat(type, volume);
            PlayerPrefs.SetFloat(type, volume);
        }
    }
}
