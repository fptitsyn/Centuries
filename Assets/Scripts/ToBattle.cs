using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToBattle : MonoBehaviour
{
    public void Play()
    {
        AudioManager.Instance.musicSource.Stop();
        AudioManager.Instance.PlaySfx("War Cry");
        SceneManager.LoadScene(4);
    }
}
