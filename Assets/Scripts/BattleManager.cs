using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }

/* This class controls the flow of the combat scene. It controls any text boxes in the scene, sets the player and boss HUDS on start, and calls the
   TakeDamage method when the buttons are pressed. */
public class BattleManager : MonoBehaviour
{

    public BattleState state;
    private Rigidbody2D playerRb;
    private Rigidbody2D bossRb;

    public Player player;

    public Boss boss;

    /* The attacking variable is used to prevent the player from spamming the attack buttons and crashing the game. When attacking is true
       they cannot use any buttons. */
    [HideInInspector] public bool attacking;
    [HideInInspector] public bool isDead;
    [HideInInspector] public int turnNumber;

    public TextMeshProUGUI dialogueText;
    public TextMeshProUGUI playerHealthText;
    public TextMeshProUGUI bossHealthText;
    public TextMeshProUGUI staminaText;
    public TextMeshProUGUI turnNumberText;

    public BattleHUD playerHUD;
    public BattleHUD bossHUD;
    public EndGameScreen endGameScreen;

    void Start()
    {
        state = BattleState.START;
        attacking = false;

        /*calls the function but "StartCoroutine" is required when adding a yield.
          Yield is used to create delays. For this project we used it to add a pause between dialogues.*/
        StartCoroutine(Setup());

    }

    /* Sets up the start of the battle. This includes the health bars, the player's stamina bar, the names of both the player and the boss, as well
       as the starting dialogue. */
    IEnumerator Setup()
    {
        turnNumber = 1;

        staminaText.text = player.currentStamina + "/" + player.maxStamina;
        playerHealthText.text = player.GetCurrentHealth() + "/" + player.maxHealth;
        bossHealthText.text = boss.GetCurrentHealth() + "/" + boss.maxHealth;
        turnNumberText.text = "TURN #1";

        dialogueText.text = "You are challenged by the " + boss.unitName + " to a battle.";

        playerHUD.SetPlayerHUD(player);
        bossHUD.SetBossHUD(boss);

        /*Waits for 2 seconds before changing the state of the game, and changing the dialogue text.*/
        yield return new WaitForSeconds(2f);

        dialogueText.text = "Player's turn to attack.";

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        turnNumberText.text = "TURN #" + turnNumber;
        PlayerTurn();
    }

    /* Called when the player or boss's health reaches 0. When the boss's health reaches 0 the game state is set to WIN and when the player's health reaches
       0 it is set to LOSE. Depending on which it is set to, a dialogue box is displayed. */
    public void EndBattle()
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

    /* When the base attack button is pressed on the players turn & and both the player and boss are currently not attacking, the Attack method is called
       for the player. */
    public void OnBaseAttackButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.Attack());
        }

    }

    /* When the crescent slash attack button is pressed on the players turn & and both the player and boss are currently not attacking, the 
       StaminaAttack method is called for the player, with a value of 1 set to the parameter that allows the method to run the proper code. */
    public void OnCrescentSlashButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.StaminaAttack(1));
        }
    }

    /* When the twin strike attack button is pressed on the players turn & and both the player and boss are currently not attacking, the 
       StaminaAttack method is called for the player, with a value of 2 set to the parameter that allows the method to run the proper code. */
    public void OnTwinStrikeButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.StaminaAttack(2));
        }

    }

    /* When the shatterfall attack button is pressed on the players turn & and both the player and boss are currently not attacking, the 
       StaminaAttack method is called for the player, with a value of 3 set to the parameter that allows the method to run the proper code. */
    public void OnShatterfallButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.StaminaAttack(3));
        }
        
    }

    // Edits the dialogue box.
    public void PlayerTurn()
    {
        dialogueText.text = "Choose your move...";
    }

 

}

