using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MastersWorkSpeedController : IMastersSpeedable
{
    private ArrowMasterController arrowMaster;
    private SwordMasterController swordMaster;
    private float mastersDownSpeed;
    private float clickFee;
    private float plusesClickFee;
    private TextMeshProUGUI clickFeeText;
    public void GetMastersSpeedController()
    {
        if (GameManager.Instance.Money >= clickFee)
        {
            //arrowMaster.SpawnObjectRepeating -= mastersDownSpeed;
          
            clickFeeText.text = clickFee.ToString();
        }
    }

    public void SetMastersSpeedParameters(ArrowMasterController arrowMasterController, SwordMasterController swordMasterController, float mastersDownSpeed, float clickFee, float plusesClickFee, TextMeshProUGUI clickFeeText)
    {
        //this.arrowMaster = arrowMasterController;
        this.swordMaster = swordMasterController;
        this.mastersDownSpeed = mastersDownSpeed;
        this.clickFee = clickFee;
        this.plusesClickFee = plusesClickFee;
        this.clickFeeText = clickFeeText;
    }
}
