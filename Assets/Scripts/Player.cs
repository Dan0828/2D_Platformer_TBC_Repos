using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public int maxStamina;
    public int currentStamina;
    int staminaUse;

    int playerDamage;

    public StaminaBar staminaBar;
    public void StaminaUsage(int staminaUse)
    {
        currentStamina = currentStamina - staminaUse;
        staminaBar.SetStamina(currentStamina);
    }

    public void StaminaRefresh()
    {
        currentStamina += 5;
        staminaBar.SetStamina(currentStamina);
    }

    public IEnumerator Attack(int move)
    {
        if (move == 1)
        {
            //Damage the enemy

            battleManager.attacking = true;

            playerDamage = Random.Range(4, 9);

            battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

            if (battleManager.boss.currentHealth < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;
            }

            battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }

        }

        if (move == 2)
        {
            staminaUse = 10;

            if (currentStamina - staminaUse < 0)
            {
                battleManager.dialogueText.text = "You do not have the energy to perform this attack.";
                yield return new WaitForSeconds(1f);
                battleManager.PlayerTurn();
                battleManager.attacking = false;
                yield break;
            }

            battleManager.attacking = true;

            playerDamage = Random.Range(10, 17);

            StaminaUsage(staminaUse);
            battleManager.staminaText.text = currentStamina + "/" + maxStamina;

            battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

            if (battleManager.boss.currentHealth < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;
            }

            battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }
        }

        if (move == 3)
        {
            staminaUse = 20;

            if (currentStamina - staminaUse < 0)
            {
                battleManager.dialogueText.text = "You do not have the energy to perform this attack.";
                yield return new WaitForSeconds(1f);
                battleManager.PlayerTurn();
                battleManager.attacking = false;
                yield break;
            }

            battleManager.attacking = true;

            playerDamage = Random.Range(6, 17);

            StaminaUsage(staminaUse);
            battleManager.staminaText.text = currentStamina + "/" + maxStamina;

            battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

            if (battleManager.boss.currentHealth < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;
            }

            battleManager.dialogueText.text = "Hit #1 successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
            }
            else
            {
                playerDamage = Random.Range(6, 17);

                battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

                battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;

                if (battleManager.boss.currentHealth < 0)
                {
                    battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
                }
                else
                {
                    battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;
                }

                battleManager.dialogueText.text = "Hit #2 successfully dealt " + playerDamage + " damage.";
                yield return new WaitForSeconds(2f);


                if (battleManager.isDead)
                {
                    battleManager.state = BattleState.WIN;
                    battleManager.EndBattle();
                }
                else
                {
                    battleManager.state = BattleState.ENEMYTURN;
                    StartCoroutine(battleManager.boss.Attack());
                }
            }
        }

        if (move == 4)
        {
            staminaUse = 30;

            if (currentStamina - staminaUse < 0)
            {
                battleManager.dialogueText.text = "You do not have the energy to perform this attack.";
                yield return new WaitForSeconds(1f);
                battleManager.PlayerTurn();
                battleManager.attacking = false;
                yield break;
            }

            battleManager.attacking = true;

            playerDamage = Random.Range(22, 31);

            StaminaUsage(staminaUse);
            battleManager.staminaText.text = currentStamina + "/" + maxStamina;

            battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

            if (battleManager.boss.currentHealth < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.currentHealth + "/" + battleManager.boss.maxHealth;
            }


            battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }

        }
    }
}
