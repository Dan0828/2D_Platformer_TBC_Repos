using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public int maxStamina;
    public int currentStamina;
    int staminaUse;
    ArrayList allDamage = new ArrayList();
    int highestDamage;

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
            allDamage.Add(playerDamage);

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
                yield return new WaitForSeconds(1f);
                highestDamage = findHighestDamage();
                StartCoroutine(battleManager.endGameScreen.Setup(1, currentHealth, highestDamage, battleManager.turnNumber));
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
            allDamage.Add(playerDamage);

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
                yield return new WaitForSeconds(1f);

                highestDamage = findHighestDamage();

                StartCoroutine(battleManager.endGameScreen.Setup(1, currentHealth, highestDamage, battleManager.turnNumber));
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
            allDamage.Add(playerDamage);

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
                yield return new WaitForSeconds(1f);
                highestDamage = findHighestDamage();
                StartCoroutine(battleManager.endGameScreen.Setup(1, currentHealth, highestDamage, battleManager.turnNumber));
            }
            else
            {
                playerDamage = Random.Range(6, 17);
                allDamage.Add(playerDamage);

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
                    yield return new WaitForSeconds(1f);
                    highestDamage = findHighestDamage();
                    StartCoroutine(battleManager.endGameScreen.Setup(1, currentHealth, highestDamage, battleManager.turnNumber));
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

            playerDamage = Random.Range(28, 35);
            allDamage.Add(playerDamage);

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
                yield return new WaitForSeconds(1f);
                highestDamage = findHighestDamage();
                StartCoroutine(battleManager.endGameScreen.Setup(1, currentHealth, highestDamage, battleManager.turnNumber));

            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }

        }

    }

    public int findHighestDamage()
    {

        for (int i = 1; i < allDamage.Count; i++)
        {

            int current = (int)allDamage[i];
            int j = i - 1;

            while (j >= 0 && (int)allDamage[j] > current)
            {
                // Swap if the element at j - 1 position is greater than the element at j position
                allDamage[j + 1] = allDamage[j];
                j--;
            }

            allDamage[j + 1] = current;
        }

        highestDamage = (int)allDamage[allDamage.Count - 1];
        return highestDamage;
    }
}
