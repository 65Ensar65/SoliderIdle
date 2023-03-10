using DG.Tweening;
using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMasterWorkController : IArrowWorkable
{
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
    private ObjectController objectController;

    public void GetArrowWorkController()
    {
        if (woodList.Count == masterRequest.WoodRequestNumber && ironList.Count == masterRequest.IronRequestNumber && GameManager.Instance.SpawnIndex != GameManager.Instance.SpawnCapacity)
        {
            masterCollider.enabled = false;
            repeating += Time.deltaTime;
            workSlider.fillAmount = repeating * .25f;


            if (repeating > workRepeating)
            {
                GameObject obj = objectPool.ActivePoolObject(ObjectTag.Arrow, masterPos.GetChild(1));
                GameManager.Instance.GunList.Add(obj);
                woodList.Clear();
                ironList.Clear();
                masterRequest.IronList.Clear();
                masterRequest.WoodList.Clear();
                repeating = 0;
                workSlider.fillAmount = 0;
                GameManager.Instance.GetAddMoney();
            }
        }

        else
        {
            masterCollider.enabled = true;
        }
    }

    public void GetArrowWoodAddListController( ObjectType objectType, Transform otherObj, ObjectPool objectPool, ObjectController objectController)
    {
        this.objectPool = objectPool;
        this.otherObj = otherObj;
        this.objectController = objectController;
        if (woodList.Count < masterRequest.WoodRequestNumber)
        {
            woodList.Add(otherObj.gameObject);
            otherObj.GetComponent<ObjectController>().GetDestroying();

            otherObj.transform.DOMove(masterPos.GetChild(5).position, .1f).OnComplete(delegate
            {
                objectPool.ReturnPoolObject(ObjectTag.Wood, otherObj.gameObject);
            });
        }
    }

    public void GetArrowIronAddListController(ObjectType objectType, Transform otherObj, ObjectPool objectPool, ObjectController objectController)
    {
        this.otherObj = otherObj;
        this.objectPool = objectPool;
        this.objectController = objectController;

        if (ironList.Count < masterRequest.IronRequestNumber)
        {
            ironList.Add(otherObj.gameObject);
            otherObj.GetComponent<ObjectController>().GetDestroying();
            otherObj.transform.DOMove(masterPos.GetChild(5).position, .1f).OnComplete(delegate
            {
                objectPool.ReturnPoolObject(ObjectTag.Iron, otherObj.gameObject);
            });
        }
    }
    public void SetArrowWorkParameters(ObjectController objectController, MasterRequestSystem masterRequest, List<GameObject> woodList, List<GameObject> ironList, Transform masterPos, Collider masterCollider, ObjectPool objectPool, float workRepeating, float repeating, Image workSlider)
    {
        this.objectController = objectController;
        this.masterRequest = masterRequest;
        this.woodList = woodList;
        this.ironList = ironList;
        this.masterPos = masterPos;
        this.masterCollider = masterCollider;
        this.objectPool = objectPool;
        this.workRepeating = workRepeating;
        this.repeating = repeating;
        this.workSlider = workSlider;
    }
}
