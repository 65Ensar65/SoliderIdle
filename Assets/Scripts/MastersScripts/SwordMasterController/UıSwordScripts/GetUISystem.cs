using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GetUISystem : SwordUIable
{
    private SwordMasterController swordMaster;
    private MasterRequestSystem masterRequest;
    private TextMeshProUGUI woodCapacity;
    private TextMeshProUGUI woodNumber;
    private TextMeshProUGUI ironCapacity;
    private TextMeshProUGUI ironNumber;
    public void GetUINumberController()
    {
        woodCapacity.text = masterRequest.WoodRequestNumber.ToString();
        woodNumber.text = swordMaster.Wood.Count.ToString();
        ironCapacity.text = masterRequest.IronRequestNumber.ToString();
        ironNumber.text = swordMaster.Iron.Count.ToString();
    }

   
    public void SetUINumberParameters(SwordMasterController swordMasterController, MasterRequestSystem masterRequest, TextMeshProUGUI woodCapacity, TextMeshProUGUI woodNumber, TextMeshProUGUI ironCapacity, TextMeshProUGUI ironNumber)
    {
        this.swordMaster = swordMasterController;
        this.masterRequest = masterRequest;
        this.woodCapacity = woodCapacity;
        this.woodNumber = woodNumber;
        this.ironCapacity = ironCapacity;
        this.ironNumber = ironNumber;

    }
}
