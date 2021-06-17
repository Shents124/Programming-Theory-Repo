using System;
using UnityEngine;

public class Cow : Animal,IDamageable
{
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    private void Awake()
    {
        maxHealth = 150;
        currentHealth = maxHealth;
    }

    public void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Cow is dead!");
        }
    }
}
