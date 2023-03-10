using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface ISwordUIlable
{
    void GetSwordUIController();
    void SetSwordUIParameters(Transform UIPos, float animSpeed);
}

public interface IMasterRequestable
{
    void GetSwordRequestController();
    void SwordRequestWoodCreate();
    void SetSwordRequestParameters(List<GameObject> woodList, List<GameObject> ironList, ObjectSpawnController spawnController, int woodRequestNumber, int ironRequestNumber, ObjectPool objectPool, float repeatTime, float repeating, bool isFree, bool isIronFree);
}

public interface ISwordWorkable
{
    void GetSwordWorkController();
    void GetSwordWoodAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool);
    void GetSwordIronAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool);
    void SetSwordWorkParameters(SwordMasterController masterController, MasterRequestSystem masterRequest, List<GameObject> woodList, List<GameObject> ironList, Transform masterPos, Collider masterCollider, ObjectPool objectPool, float workRepeating, float repeating, Image workSlider, UpgradeController upgradeController);
}
