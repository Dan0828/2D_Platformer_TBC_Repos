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
    int baseAtkDmg;
    int bossAttack;
    int bossDamage;

    public TextMeshProUGUI dialogueText;

    public PlayerBattleHUD playerHUD;
    public BossBattleHUD bossHUD;

    void Start()
    {
        state = BattleState.START;

        /*calls the function but "StartCoroutine" is required when adding a yield*/
        StartCoroutine(Setup());
    }

    IEnumerator Setup()
    {

        player = playerRb.GetComponent<Unit>();
        boss = bossRb.GetComponent<Unit>();
        dialogueText.text = "You are challenged by the " + boss.unitName + " to a battle.";

        playerHUD.SetHUD(player);
        playerHUD.SetStamina(player);
        bossHUD.SetHUD(boss);

        /*Waits for 2 seconds before changing the state of the game, and changing the dialogue text.*/
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        dialogueText.text = "Player's turn to attack.";

        yield return new WaitForSeconds(2f);
        PlayerTurn();
    }

    IEnumerator PlayerBaseAttack()
    {
        //Damage the enemy

        baseAtkDmg = Random.Range(4, 9);

        bool isDead = boss.TakeDamage(baseAtkDmg);
        dialogueText.text = "Your attack successfully did " + baseAtkDmg + " damage.";
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
        yield return new WaitForSeconds(1f);

         bossAttack = Random.Range(1, 101);

         if (bossAttack <= 50)
         {
            
             bossDamage = Random.Range(5, 8);

             dialogueText.text = boss.unitName + " uses Slash.";

             yield return new WaitForSeconds(1f);

             dialogueText.text = boss.unitName + " dealt " + bossDamage + " damage.";
             
         }
          
         else if (bossAttack <= 75 && bossAttack > 50)
         {
            
             bossDamage = Random.Range(11, 14);

             dialogueText.text = boss.unitName + " uses Night Daze.";

             yield return new WaitForSeconds(1f);

             dialogueText.text = boss.unitName + " dealt " + bossDamage + " damage.";
         }
          
         else if (bossAttack > 75  && bossAttack <= 90 )
         {
            
             bossDamage = Random.Range(17, 21);

             dialogueText.text = boss.unitName + "  uses Black Hole Eclipse.";

             yield return new WaitForSeconds(1f);

             dialogueText.text = boss.unitName + " dealt " + bossDamage + " damage.";

         }
          
         else if (bossAttack > 90)
         {
            
             bossDamage = Random.Range(22, 26);

             dialogueText.text = boss.unitName + "  uses Wrath of the Void.";

             yield return new WaitForSeconds(1f);

             dialogueText.text = boss.unitName + " dealt " + bossDamage + " damage.";

         }
        

        yield return new WaitForSeconds(1f);

        bool isDead = player.TakeDamage(bossDamage);

        

        if(isDead)
        {
            state = BattleState.LOSE;
            EndBattle();

        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
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
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerBaseAttack());
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose your move...";
    }

 

}
