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
        if (health - damage <= 0f)
        {
            Debug.Log("Died");
            return;
        }

        health -= damage;
        hpText.text = health.ToString(CultureInfo.InvariantCulture);
    }
}
