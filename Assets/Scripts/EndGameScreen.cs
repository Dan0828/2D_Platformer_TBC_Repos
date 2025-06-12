using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    public TextMeshProUGUI endGameTitle;
    public TextMeshProUGUI leftoverHealth;
    public TextMeshProUGUI highestDamageDealt;
    public TextMeshProUGUI turnNumberCompletedOn;
    public GameObject menuButton;

    public IEnumerator Setup(int endTitle, int currentHealth, int highestDamage, int completedTurnNumber)
    {
        gameObject.SetActive(true);
        menuButton.SetActive(false);

        yield return new WaitForSeconds(1f);


        if (endTitle == 1)
        {
            endGameTitle.text = "YOU WIN";

            yield return new WaitForSeconds(1f);
            leftoverHealth.text = "Remaining Health: " + currentHealth;

            yield return new WaitForSeconds(1f);
            highestDamageDealt.text = "Highest Damage Dealt: " + highestDamage;

            yield return new WaitForSeconds(1f);
            turnNumberCompletedOn.text = "Battle Completed on turn #" + completedTurnNumber;

            yield return new WaitForSeconds(1f);
            menuButton.SetActive(true);
        }
        else
        {
            endGameTitle.text = "GAME OVER";

            yield return new WaitForSeconds(1f);
            menuButton.SetActive(true);
        }

        

    }
}
