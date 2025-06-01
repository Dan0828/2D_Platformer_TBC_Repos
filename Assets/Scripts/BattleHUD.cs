using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleHUD : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public Image hp;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        float hpFill = unit.currentHealth / unit.maxHealth;
        hp.fillAmount = hpFill;
    }
}
