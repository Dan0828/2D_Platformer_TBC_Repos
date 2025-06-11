using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    
    public string unitName;
    public int maxHealth;
    public int currentHealth;

    public BattleManager battleManager;

    public HealthBar healthBar;

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

}
