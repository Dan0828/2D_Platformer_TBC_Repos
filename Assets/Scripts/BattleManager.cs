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

    public TextMeshProUGUI dialogueText;

    public PlayerBattleHUD playerHUD;
    public BossBattleHUD bossHUD;

    public HealthBar playerHealthBar; 

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

        bool isDead = boss.TakeDamage(player.damage);
        yield return new WaitForSeconds(2f);

        //check if the enemy is dead
        //change state based on enemy status

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
