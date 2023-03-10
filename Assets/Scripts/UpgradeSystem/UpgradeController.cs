using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeController : Base
{
    [Title("Masters Work Speed")]
    public float MastersWorkSpeed;
    public float ClickFee;
    public float ClickFeePluses;
    public TextMeshProUGUI ClickFeeText;

    [Title("Get Money Up Values")]
    public float ClickMoneyFee;
    public float ClickMoneyPlusesFee;
    public TextMeshProUGUI ClickMoneyFeeText;

    [Title("Masters Up Gun Values")]
    public float ClickMasterGunFee;
    public float ClickMasterGunPlusesFee;
    public TextMeshProUGUI ClickMasterGunFeeText;
    public void GetMastersSpeedControl()
    {
        if (GameManager.Instance.Money >= ClickFee)
        {
            GameManager.Instance.Money -= ClickFee;
            swordMaster.SpawnObjectRepeating -= MastersWorkSpeed;
            arrowMaster.SpawnObjectRepeating -= MastersWorkSpeed;
            ClickFee += ClickFeePluses;
        }
    }

    public void GetUpMoneyControl()
    {
        if (GameManager.Instance.Money >= ClickMoneyFee)
        {
            GameManager.Instance.Money -= GameManager.Instance.PlusesMoney;
            ClickMoneyFee += ClickMoneyPlusesFee;
        }
    }

    public void GetGunUpgradeControl()
    {
        if (GameManager.Instance.Money >= ClickMasterGunFee)
        {
            GameManager.Instance.Money -= ClickMasterGunFee;
            GameManager.Instance.PlusesMoney += 2;
            ClickMasterGunFee += ClickMasterGunPlusesFee;
        }
    }

    private void Update()
    {
        ClickFeeText.text = ClickFee.ToString();
        ClickMoneyFeeText.text = ClickMoneyFee.ToString();
        ClickMasterGunFeeText.text = ClickMasterGunFee.ToString();

        if (Input.GetMouseButtonDown(1))
        {
            GameManager.Instance.Money += 20;
        }
    }
}
