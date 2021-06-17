using UnityEngine;

public interface IDamageable 
{
    public int currentHealth { get; set; }
    public int maxHealth { get; set; }

    public void TakeDame(int amoutOfDame);
}
