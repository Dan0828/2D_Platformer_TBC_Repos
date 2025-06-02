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
        //dialogueText.text = boss.unitName;
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

    void PlayerTurn()
    {
        dialogueText.text = "Choose your move...";
    }

    public void OnBaseAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }

        StartCoroutine(PlayerBaseAttack());
    }

}
