using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Unit
{
    public int maxStamina;
    public int currentStamina;
    int staminaUse; // Value set depending on which move the user decides to attack with. The value will be taken off of the current stamina.
    ArrayList allDamage = new ArrayList(); // Array list that contains all damage that the user deals throughout the battle. Sorted to find the highest.
    int highestDamage;
    int playerDamage;

    public StaminaBar staminaBar;
    public void StaminaUsage(int staminaUse)
    {
        currentStamina = currentStamina - staminaUse;
        staminaBar.SetStamina(currentStamina);
    }

    /* Called at the start of every turn for the user.
       Adds 5 stamina to the player's current stamina and calls the SetStamina function from the staminaBar script to edit the stamina bar.*/
    public void StaminaRefresh()
    {
        currentStamina += 5;
        staminaBar.SetStamina(currentStamina);
    }

    /* Called when the BaseAttack button is clicked.
     -  Generates a random number for the damage, then takes that damage off of the bosses health using the TakeDamage method that also returns if
        the boss is dead or alive using true and false.
     -  If it returns true, the battle state is changed to WIN and the EndBattle method from the BattleManager
        script is called, then the end game screen is displayed. 
     -  If it returns false, the battle state is changed to ENEMYTURN and the attack function for the boss
        is called. */
    public override IEnumerator Attack()
    {

        battleManager.attacking = true;

        playerDamage = Random.Range(4, 9);

        // Adds the damage the player dealt with this attack to the allDamage ArrayList that contains all damage dealt by the player.
        allDamage.Add(playerDamage);

        battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

        if (battleManager.boss.GetCurrentHealth() < 0)
        {
            battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
        }
        else
        {
            battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;
        }

        battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
        yield return new WaitForSeconds(2f);

        if (battleManager.isDead)
        {
            battleManager.state = BattleState.WIN;
            battleManager.EndBattle();
            yield return new WaitForSeconds(1f);
            highestDamage = findHighestDamage();
            StartCoroutine(battleManager.endGameScreen.Setup(1, GetCurrentHealth(), highestDamage, battleManager.turnNumber));
        }
        else
        {
            battleManager.state = BattleState.ENEMYTURN;
            StartCoroutine(battleManager.boss.Attack());
        }
    }

    /* Called when the button for any move that requires stamina is clicked.
    The value "move" is set when called depending on the button they press. */
    public IEnumerator StaminaAttack(int move)
    {

        if (move == 1)
        {
            staminaUse = 10;

            // Outputs an error message in the dialogue box that tells the player they do not have enough stamina for this move.
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

            if (battleManager.boss.GetCurrentHealth() < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;
            }

            battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
                yield return new WaitForSeconds(1f);

                highestDamage = findHighestDamage();

                StartCoroutine(battleManager.endGameScreen.Setup(1, GetCurrentHealth(), highestDamage, battleManager.turnNumber));
            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }
        }

        if (move == 2)
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

            if (battleManager.boss.GetCurrentHealth() < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;
            }

            battleManager.dialogueText.text = "Hit #1 successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
                yield return new WaitForSeconds(1f);
                highestDamage = findHighestDamage();
                StartCoroutine(battleManager.endGameScreen.Setup(1, GetCurrentHealth(), highestDamage, battleManager.turnNumber));
            }
            else
            {
                playerDamage = Random.Range(6, 17);
                allDamage.Add(playerDamage);

                battleManager.isDead = battleManager.boss.TakeDamage(playerDamage);

                battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;

                if (battleManager.boss.GetCurrentHealth() < 0)
                {
                    battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
                }
                else
                {
                    battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;
                }

                battleManager.dialogueText.text = "Hit #2 successfully dealt " + playerDamage + " damage.";
                yield return new WaitForSeconds(2f);


                if (battleManager.isDead)
                {
                    battleManager.state = BattleState.WIN;
                    battleManager.EndBattle();
                    yield return new WaitForSeconds(1f);
                    highestDamage = findHighestDamage();
                    StartCoroutine(battleManager.endGameScreen.Setup(1, GetCurrentHealth(), highestDamage, battleManager.turnNumber));
                }
                else
                {
                    battleManager.state = BattleState.ENEMYTURN;
                    StartCoroutine(battleManager.boss.Attack());
                }
            }
        }

        if (move == 3)
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

            if (battleManager.boss.GetCurrentHealth() < 0)
            {
                battleManager.bossHealthText.text = 0 + "/" + battleManager.boss.maxHealth;
            }
            else
            {
                battleManager.bossHealthText.text = battleManager.boss.GetCurrentHealth() + "/" + battleManager.boss.maxHealth;
            }


            battleManager.dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (battleManager.isDead)
            {
                battleManager.state = BattleState.WIN;
                battleManager.EndBattle();
                yield return new WaitForSeconds(1f);
                highestDamage = findHighestDamage();
                StartCoroutine(battleManager.endGameScreen.Setup(1, GetCurrentHealth(), highestDamage, battleManager.turnNumber));

            }
            else
            {
                battleManager.state = BattleState.ENEMYTURN;
                StartCoroutine(battleManager.boss.Attack());
            }

        }

    }

    /* This method is used to sort the allDamage array list using insertion sort to find the highest value. Once sorted the last value in the array is taken
       and set to a variable. That variable is returned, and used to display the highest amount of damage the player dealt by the end of the game if they win. */
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
