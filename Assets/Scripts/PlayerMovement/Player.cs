using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene(3);
        }

        hpText.text = health.ToString(CultureInfo.InvariantCulture);
    }
}
