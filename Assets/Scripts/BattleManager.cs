using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WIN, LOSE }

public class BattleManager : MonoBehaviour
{

    public BattleState state;
    private Rigidbody2D playerRb;
    private Rigidbody2D bossRb;

    public Player player;

    public Boss boss;

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

        /*calls the function but "StartCoroutine" is required when adding a yield*/
        StartCoroutine(Setup());

    }

    IEnumerator Setup()
    {
        turnNumber = 1;

        staminaText.text = player.currentStamina + "/" + player.maxStamina;
        playerHealthText.text = player.currentHealth + "/" + player.maxHealth;
        bossHealthText.text = boss.currentHealth + "/" + boss.maxHealth;
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

    public void OnBaseAttackButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.Attack(1));
        }

    }

    public void OnCrescentSlashButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.Attack(2));
        }
    }

    public void OnTwinStrikeButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.Attack(3));
        }

    }

    public void OnShatterfallButton()
    {
        if (state == BattleState.PLAYERTURN && !attacking)
        {
            StartCoroutine(player.Attack(4));
        }
        
    }
    public void PlayerTurn()
    {
        dialogueText.text = "Choose your move...";
    }

 

}

