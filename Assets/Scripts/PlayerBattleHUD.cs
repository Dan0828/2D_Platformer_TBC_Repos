using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerBattleHUD : BattleHUD
{
    public Image stamina;

    public void SetStamina(Unit unit)
    {
        stamina.fillAmount = unit.currentStamina;
    }
}
