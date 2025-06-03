using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }



public class BattleManager : MonoBehaviour
{

    public BattleState state;
    public Rigidbody2D playerRb;
    public Rigidbody2D bossRb;

    Unit player;
    Unit boss;
    int playerDamage;
    int bossAttack;
    int bossDamage;
    int staminaUse;
    bool attacking;
    bool staminaCheck;

    public TextMeshProUGUI dialogueText;

    public PlayerBattleHUD playerHUD;
    public BossBattleHUD bossHUD;

    void Start()
    {
        state = BattleState.START;
        attacking = false;
        /*calls the function but "StartCoroutine" is required when adding a yield*/
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {

        player = playerRb.GetComponent<Unit>();
        boss = bossRb.GetComponent<Unit>();
        dialogueText.text = "You are challenged by the " + boss.unitName + " to a battle.";

        playerHUD.SetHUD(player);
        bossHUD.SetHUD(boss);

        /*Waits for 2 seconds before changing the state of the game, and changing the dialogue text.*/
        yield return new WaitForSeconds(2f);

        dialogueText.text = "Player's turn to attack.";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerBaseAttack()
    {
        //Damage the enemy

        attacking = true;

        playerDamage = Random.Range(4, 9);

        bool isDead = boss.TakeDamage(playerDamage);
        dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator PlayerCrescentSlash()
    {
        staminaCheck = true;
        while (staminaCheck)
        {
            //Damage the enemy

            staminaUse = 10;

            if (player.currentStamina - staminaUse < 0)
            {
                dialogueText.text = "You do not have the energy to perform this attack.";
                yield return new WaitForSeconds(1f);
                PlayerTurn();
                staminaCheck = false;
                attacking = false;
                break;
            }

            attacking = true;

            playerDamage = Random.Range(8, 13);


            player.StaminaUsage(staminaUse);

            bool isDead = boss.TakeDamage(playerDamage);
            dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);

            if (isDead)
            {
                staminaCheck = false;
                state = BattleState.WIN;
                EndBattle();
            }
            else
            {
                staminaCheck = false;
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }

    }

    IEnumerator PlayerTwinStrike()
    {
        //Damage the enemy

        attacking = true;

        playerDamage = Random.Range(6, 17);

        staminaUse = 20;
        player.StaminaUsage(staminaUse);

        bool isDead = boss.TakeDamage(playerDamage);
        dialogueText.text = "Hit #1 successfully dealt " + playerDamage + " damage.";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            playerDamage = Random.Range(6, 17);

            isDead = boss.TakeDamage(playerDamage);
            dialogueText.text = "Hit #2 successfully dealt " + playerDamage + " damage.";
            yield return new WaitForSeconds(2f);


            if (isDead)
            {
                state = BattleState.WIN;
                EndBattle();
            }
            else
            {
                state = BattleState.ENEMYTURN;
                StartCoroutine(EnemyTurn());
            }
        }

    }

    IEnumerator PlayerShatterfall()
    {
        //Damage the enemy

        attacking = true;

        playerDamage = Random.Range(18, 27);

        staminaUse = 30;
        player.StaminaUsage(staminaUse);

        bool isDead = boss.TakeDamage(playerDamage);
        dialogueText.text = "Your attack successfully dealt " + playerDamage + " damage.";
        yield return new WaitForSeconds(2f);

        if (isDead)
        {
            state = BattleState.WIN;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }

    IEnumerator EnemyTurn()
    {
         bossAttack = Random.Range(1, 101);

         if (bossAttack <= 60)
         {            
             bossDamage = Random.Range(5, 8);

             dialogueText.text = boss.unitName + " uses Slash.";

             yield return new WaitForSeconds(2f);
         }
          
         else if (bossAttack > 60 && bossAttack <= 85)
         {         
             bossDamage = Random.Range(11, 14);

             dialogueText.text = boss.unitName + " uses Night Daze.";

             yield return new WaitForSeconds(2f);
         }
          
         else if (bossAttack > 85  && bossAttack <= 95 )
         {  
             bossDamage = Random.Range(17, 21);

             dialogueText.text = boss.unitName + " uses Black Hole Eclipse.";

             yield return new WaitForSeconds(2f);
         }
          
         else if (bossAttack > 95)
         {          
             bossDamage = Random.Range(28, 32);

             dialogueText.text = boss.unitName + " uses Wrath of the Void.";

             yield return new WaitForSeconds(2f);
         }

        bool isDead = player.TakeDamage(bossDamage);

        dialogueText.text = "The attack dealt " + bossDamage + " damage.";

        yield return new WaitForSeconds(1f);

        attacking = false;
        

        if(isDead)
        {
            state = BattleState.LOSE;
            EndBattle();

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
            player.StaminaRefresh();
        }

        
    }

    void EndBattle()
    {
        if (state == BattleState.WIN)
        {
            dialogueText.text = "You defeated the " + boss.unitName + ".";
        }
        else if (state == BattleState.LOSE)
        {
            dialogueText.text = "You were defeated by the " + boss.unitName + ".";
        }
    }

    public void OnBaseAttackButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(PlayerBaseAttack());
        }

    }

    public void OnCrescentSlashButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(PlayerCrescentSlash());
        }
    }

    public void OnTwinStrikeButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(PlayerTwinStrike());
        }

    }

    public void OnShatterfallButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(PlayerShatterfall());
        }
        
    }
    void PlayerTurn()
    {
        dialogueText.text = "Choose your move...";
    }

 

}
