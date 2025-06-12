using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public ReadName readName;

    public void SetPlayerHUD(Player player)
    {;
        nameText.text = readName.LoadLastName();
    }

    public void SetBossHUD(Boss boss)
    {
        nameText.text = boss.unitName;
    }

}
