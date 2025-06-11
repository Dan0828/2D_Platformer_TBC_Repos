using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Unit
{
    int bossAttack;
    int bossDamage;

    public IEnumerator Attack()
    {
        bossAttack = Random.Range(1, 101);

        if (bossAttack <= 40)
        {
            bossDamage = Random.Range(6, 11);

            battleManager.dialogueText.text = unitName + " uses Slash.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 40 && bossAttack <= 65)
        {
            bossDamage = Random.Range(12, 16);

            battleManager.dialogueText.text = unitName + " uses Night Daze.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 65 && bossAttack <= 85)
        {
            bossDamage = Random.Range(18, 23);

            battleManager.dialogueText.text = unitName + " uses Black Hole Eclipse.";

            yield return new WaitForSeconds(2f);
        }

        else if (bossAttack > 85)
        {
            bossDamage = Random.Range(28, 32);

            battleManager.dialogueText.text = unitName + " uses Wrath of the Void.";

            yield return new WaitForSeconds(2f);

        }


        battleManager.isDead = battleManager.player.TakeDamage(bossDamage);

        if (battleManager.player.currentHealth < 0)
        {
            battleManager.playerHealthText.text = 0 + "/" + battleManager.player.maxHealth;
        }
        else
        {
            battleManager.playerHealthText.text = battleManager.player.currentHealth + "/" + battleManager.player.maxHealth;
        }

        battleManager.dialogueText.text = "The attack dealt " + bossDamage + " damage.";

        yield return new WaitForSeconds(1f);

        battleManager.attacking = false;


        if (battleManager.isDead)
        {
            battleManager.state = BattleState.LOSE;
            battleManager.EndBattle();

        }
        else
        {
            battleManager.state = BattleState.PLAYERTURN;
            battleManager.PlayerTurn();
            if (battleManager.player.currentStamina < 50)
            {
                battleManager.player.StaminaRefresh();
                battleManager.staminaText.text = battleManager.player.currentStamina + "/" + battleManager.player.maxStamina;
            }
        }


    }
}
