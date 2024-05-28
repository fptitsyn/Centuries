using System.Collections.Generic;
using UnityEngine;

namespace Audio
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
    
        [Header("------------------Audio Source-----------------")]
        public AudioSource musicSource;
        public AudioSource sfxSource;
        [Header("------------------Audio Clip-----------------")]

        public List<Sound> music, sounds;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void PlayMusic(string soundName)
        {
            Sound s = music.Find(x => x.name == soundName);

            if (s != null)
            {
                musicSource.clip = s.audio;
                musicSource.Play();
            }
        }
    
        public void PlaySfx(string soundName)
        {
            Sound s = sounds.Find(x => x.name == soundName);

            if (s != null)
            {
                sfxSource.PlayOneShot(s.audio);
            }
        }
    }
}