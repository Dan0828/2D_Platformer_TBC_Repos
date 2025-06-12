using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    
    public string unitName;
    public int maxHealth;
    private int currentHealth = 100;

    public BattleManager battleManager;

    public HealthBar healthBar;

    /* method is inherited to the Player & Boss class. 
       Takes the damage parameter and subtracts it from the current health. Then changes the health bar to display the new current health.
       Then checks if the current health is equal to or below zero. If it is, the method returns true meaning the unit is dead. If not, it returns false
       meaning the unit is still alive. */
    public bool TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Abstract Attack method that is overridden in the Player and Boss scripts.
    public abstract IEnumerator Attack();

    public int GetCurrentHealth()
    {
        return currentHealth;
    }

    public void SetCurrentHealth(int cH)
    {
        currentHealth = cH;
    }

}
