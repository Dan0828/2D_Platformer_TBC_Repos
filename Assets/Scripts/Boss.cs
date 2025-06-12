using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Unit
{
    int bossAttack;
    int bossDamage;

    /* overrides the Attack method from the Unit script. Generates a random number from 1-100 that is used to determine which move the boss will use.
       If the number ranges from 1-50, the weakest attack is used. If it ranges from 50-75, the second weakest attack is used. If it ranges from 75-90,
       the second strongest attack is used. Lastly, if it ranges from 90-100, the strongest attack is used. Checks if the player's health reaches 0. 
     - If it returns true, the state is changed to LOSE and a game over screen is displayed that allows the player to return to the menu. 
     - If it returns false, the player turn function is run, as well as the stamina refresh that adds 5 stamina to the player. */
    public override IEnumerator Attack()
    {
        bossAttack = Random.Range(1, 101);

        if (bossAttack <= 50)
        {
            bossDamage = Random.Range(6, 11);

            battleManager.dialogueText.text = unitName + " uses Slash.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 50 && bossAttack <= 75)
        {
            bossDamage = Random.Range(12, 16);

            battleManager.dialogueText.text = unitName + " uses Night Daze.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 75 && bossAttack <= 90)
        {
            bossDamage = Random.Range(18, 23);

            battleManager.dialogueText.text = unitName + " uses Black Hole Eclipse.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 90)
        {
            bossDamage = Random.Range(28, 33);

            battleManager.dialogueText.text = unitName + " uses Wrath of the Void.";

            yield return new WaitForSeconds(2f);

        }


        battleManager.isDead = battleManager.player.TakeDamage(bossDamage);

        if (battleManager.player.GetCurrentHealth() < 0)
        {
            battleManager.playerHealthText.text = 0 + "/" + battleManager.player.maxHealth;
        }
        else
        {
            battleManager.playerHealthText.text = battleManager.player.GetCurrentHealth() + "/" + battleManager.player.maxHealth;
        }

        battleManager.dialogueText.text = "The attack dealt " + bossDamage + " damage.";

        yield return new WaitForSeconds(1f);

        battleManager.attacking = false;


        if (battleManager.isDead)
        {
            battleManager.state = BattleState.LOSE;
            battleManager.EndBattle();
            yield return new WaitForSeconds(2f);
            StartCoroutine(battleManager.endGameScreen.Setup(2, 0, 0, 0));
        }

        else
        {
            battleManager.state = BattleState.PLAYERTURN;
            battleManager.turnNumber += 1;
            battleManager.turnNumberText.text = "TURN #" + battleManager.turnNumber;

            battleManager.PlayerTurn();

            if (battleManager.player.currentStamina < 50)
            {
                battleManager.player.StaminaRefresh();
                battleManager.staminaText.text = battleManager.player.currentStamina + "/" + battleManager.player.maxStamina;
            }
        }


    }
}
