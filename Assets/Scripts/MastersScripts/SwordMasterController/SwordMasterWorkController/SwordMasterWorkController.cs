using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordMasterWorkController : ISwordWorkable
{
    private SwordMasterController masterController;
    private MasterRequestSystem masterRequest;
    private List<GameObject> woodList;
    private List<GameObject> ironList;
    private Transform masterPos;
    private Transform otherObj;
    private Collider masterCollider;
    private ObjectPool objectPool;
    private float workRepeating;
    private float repeating;
    private Image workSlider;
    private UpgradeController upgradeController;

    public void GetSwordWorkController()
    {
        if (woodList.Count == masterRequest.WoodRequestNumber && ironList.Count == masterRequest.IronRequestNumber)
        {
            repeating += Time.deltaTime;
            workSlider.fillAmount = repeating * .25f;
            Debug.Log("Is Work");

            masterCollider.enabled = false;

            if (repeating > workRepeating)
            {
                if (upgradeController.ClickMasterGunFee <= 1)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Sword, masterPos.GetChild(1));
                    GameManager.Instance.GunList.Add(obj);
                    workSlider.fillAmount = 0;
                }

                else if (upgradeController.ClickMasterGunFee > 1 && upgradeController.ClickMasterGunFee <= 3)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Sword2, masterPos.GetChild(1));
                    GameManager.Instance.GunList.Add(obj);
                    workSlider.fillAmount = 0;
                }

                else if (upgradeController.ClickMasterGunFee > 3)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Sword3, masterPos.GetChild(1));
                    GameManager.Instance.GunList.Add(obj);
                    workSlider.fillAmount = 0;
                }
                woodList.Clear();
                ironList.Clear();
                masterRequest.IronList.Clear();
                masterRequest.WoodList.Clear();
                repeating = 0;
                GameManager.Instance.GetAddMoney();

            }
        }
        else
        {
            masterCollider.enabled = true;
        }
    }

    public void GetSwordWoodAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool)
    {
        this.objectPool = objectPool;
        this.otherObj = otherObj;
        if (woodList.Count < masterRequest.WoodRequestNumber)
        {
            woodList.Add(otherObj.gameObject);
            objectPool.ReturnPoolObject(ObjectTag.Wood, otherObj.gameObject);
        }
    }

    public void GetSwordIronAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool)
    {
        this.otherObj = otherObj;
        this.objectPool = objectPool;

        if (ironList.Count < masterRequest.IronRequestNumber)
        {
            ironList.Add(otherObj.gameObject);
            objectPool.ReturnPoolObject(ObjectTag.Iron, otherObj.gameObject);
        }
    }
    public void SetSwordWorkParameters(SwordMasterController masterController, MasterRequestSystem masterRequest, List<GameObject> woodList, List<GameObject> ironList, Transform masterPos, Collider masterCollider, ObjectPool objectPool, float workRepeating, float repeating, Image workSlider, UpgradeController upgradeController)
    {
        this.masterController = masterController;
        this.masterRequest = masterRequest;
        this.woodList = woodList;
        this.ironList = ironList;
        this.masterPos = masterPos;
        this.masterCollider = masterCollider;
        this.objectPool = objectPool;
        this.workRepeating = workRepeating;
        this.repeating = repeating;
        this.workSlider = workSlider;
        this.upgradeController = upgradeController;
    }
}
