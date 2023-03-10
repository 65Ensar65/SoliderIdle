using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SwordMasterMoneyController : IGrandMoneyable
{
    private TextMeshProUGUI moneyText;
    private float money;
    private float plusesMoney;
    public void GetGrandMoneyController()
    {
        money += plusesMoney;
    }

    public void SetGrandMoneyParameters(TextMeshProUGUI moneyText, float money, float plusesMoney)
    {
        this.moneyText = moneyText;
        this.money = money;
        this.plusesMoney = plusesMoney;
        moneyText.text = money.ToString();
    }
}
