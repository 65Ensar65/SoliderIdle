using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public interface ISwordUpgradelable
{
    void GetSpawnSpeedController();
}

public interface ISpawnUpgradable
{
    void GetSpawnUpgradeController();
    void SetSpawnUpgradeParameters(ObjectSpawnController repeating);
}

public interface SwordUIable
{
    void GetUINumberController();
    void SetUINumberParameters(SwordMasterController swordMasterController, MasterRequestSystem masterRequest, TextMeshProUGUI woodCapacity, TextMeshProUGUI woodNumber, TextMeshProUGUI ironCapacity, TextMeshProUGUI ironNumber);
}
public interface ArrowUIable
{
    void GetUINumberController();
    void SetUINumberParameters(ArrowMasterController arrowMasterController, MasterRequestSystem masterRequest, TextMeshProUGUI woodCapacity, TextMeshProUGUI woodNumber, TextMeshProUGUI ironCapacity, TextMeshProUGUI ironNumber);
}

public interface IMastersSpeedable
{
    void GetMastersSpeedController();
    void SetMastersSpeedParameters(ArrowMasterController arrowMasterController, SwordMasterController swordMasterController, float mastersDownSpeed, float clickFee, float plusesClickFee, TextMeshProUGUI clickFeeText);
}
