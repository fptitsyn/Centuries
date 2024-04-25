using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;

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
            Debug.Log("Died");
        }

        hpText.text = health.ToString(CultureInfo.InvariantCulture);
    }
}
