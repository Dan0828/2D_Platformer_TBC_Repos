using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public string unitName;
    public int maxHealth;
    public int currentHealth;
    public int maxStamina;
    public int currentStamina;

    public HealthBar healthBar;
    public StaminaBar staminaBar;

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

    public void StaminaUsage(int staminaUse)
    {
        currentStamina -= staminaUse;
        staminaBar.SetStamina(currentStamina);
    }

    public void StaminaRefresh()
    {
        currentStamina += 5;
    }

}
