using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float health;

    public void TakeDamage(float damage)
    {
        if (health - damage <= 0f)
        {
            Debug.Log("Died");
            return;
        }

        health -= damage;
    }
}
