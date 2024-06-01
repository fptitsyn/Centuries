using Audio;
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
            AudioManager.Instance.PlaySfx("Click 4");
            
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
            
            mixer.SetFloat(type, Mathf.Log10(volume) * 20);
            PlayerPrefs.SetFloat(type, volume);
        }
    }
}
