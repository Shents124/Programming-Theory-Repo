using UnityEngine;

public class Dog : Animal,IDamageable
{
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }
    
    private void Awake()
    {
        maxHealth = 100;
        currentHealth = maxHealth;
    }
    public void TakeDame(int amoutOfDame)
    {
        currentHealth -= amoutOfDame;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            Debug.Log("Dog is dead!");
        }
    }
}
