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

    public bool TakeDamage(int dmg)
    {
        currentHealth -= dmg;

        if (currentHealth <= 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void BaseAttackDamage()
    {

    }



}
