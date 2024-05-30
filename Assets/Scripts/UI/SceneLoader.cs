using Audio;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int sceneIndex)
        {
            AudioManager.Instance.PlaySfx("Click " + Random.Range(1, 5));
            SceneManager.LoadScene(sceneIndex);
        }

        public void ExitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}
