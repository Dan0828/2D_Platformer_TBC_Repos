using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndGameScreen : MonoBehaviour
{
    public TextMeshProUGUI endGameTitle;

    public IEnumerator Setup(int endTitle, int remainingHealth)
    {
        gameObject.SetActive(true);
        yield return new WaitForSeconds(1f);


        if (endTitle == 1)
        {
            endGameTitle.text = "YOU WIN";
        }
        else
        {
            endGameTitle.text = "GAME OVER";
        }
    }
}
