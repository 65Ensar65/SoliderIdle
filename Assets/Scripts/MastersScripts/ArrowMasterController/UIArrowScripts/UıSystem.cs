using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UıSystem : ArrowUIable
{
    private ArrowMasterController arrowMaster;
    private MasterRequestSystem masterRequest;
    private TextMeshProUGUI woodCapacity;
    private TextMeshProUGUI woodNumber;
    private TextMeshProUGUI ironCapacity;
    private TextMeshProUGUI ironNumber;
    public void GetUINumberController()
    {
        woodCapacity.text = masterRequest.WoodRequestNumber.ToString();
        woodNumber.text = arrowMaster.Wood.Count.ToString();
        ironCapacity.text = masterRequest.IronRequestNumber.ToString();
        ironNumber.text = arrowMaster.Iron.Count.ToString();
    }


    public void SetUINumberParameters(ArrowMasterController arrowMasterController, MasterRequestSystem masterRequest, TextMeshProUGUI woodCapacity, TextMeshProUGUI woodNumber, TextMeshProUGUI ironCapacity, TextMeshProUGUI ironNumber)
    {
        this.arrowMaster = arrowMasterController;
        this.masterRequest = masterRequest;
        this.woodCapacity = woodCapacity;
        this.woodNumber = woodNumber;
        this.ironCapacity = ironCapacity;
        this.ironNumber = ironNumber;

    }
}
