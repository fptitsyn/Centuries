using System.Collections;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private TMP_Text hpText;
    
        [SerializeField] private float health;

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
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(6);
        }
    }
}
