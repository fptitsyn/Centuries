using System;
using Audio;
using System.Collections;
using System.Globalization;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TMP_Text hpText;
    
        [SerializeField] private float health;

        private void Start()
        {
            if (PlayerPrefs.HasKey(NameHelper.LevelPrefs))
            {
                health += PlayerPrefs.GetInt(NameHelper.LevelPrefs) * 5;
            }
        }

        public void TakeDamage(float damage)
        {
            if (health - damage > 0f)
            {
                health -= damage;
            }
            else
            {
                health = 0;
                StartCoroutine(FightLost());
            }

            hpText.text = health.ToString(CultureInfo.InvariantCulture);
        }

        private IEnumerator FightLost()
        {
            Destroy(BattleManager.Instance);
            AudioManager.Instance.musicSource.Stop();
            AudioManager.Instance.StopCheer();
            AudioManager.Instance.PlaySfx("Defeat SFX");
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(6);
        }
    }
}
