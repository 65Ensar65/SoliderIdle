using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMasterController : Base
{
    private IGrandMoneyable grandMoneyable;
    private IArrowWorkable arrowWorkable;

    [HideInInspector] public IMasterRequestable swordRequestable;

    public ObjectType objectType = ObjectType.ArrowMaster;

    [Title("Master UI Values")]
    public Image WorkSlider;

    [Title("Arrow Request Values")]
    public List<GameObject> Wood = new List<GameObject>();
    public List<GameObject> Iron = new List<GameObject>();
    public MasterRequestSystem MasterRequest;
    public float WorkRepeating;
    public float Repeating;
    public float SpawnObjectRepeating;


    public void Start()
    {
        grandMoneyable = new ArrowMasterMoneyController();

        grandMoneyable.SetGrandMoneyParameters(GameManager.Instance.MoneyText, GameManager.Instance.Money, GameManager.Instance.PlusesMoney);

        swordRequestable = new MasterRequestController();
        swordRequestable.SetSwordRequestParameters(MasterRequest.WoodList, MasterRequest.IronList, e_objectSpawn,
        MasterRequest.WoodRequestNumber, MasterRequest.IronRequestNumber, e_objectPool, 0, SpawnObjectRepeating, MasterRequest.IsWoodFree, MasterRequest.IsIronFree);

        arrowWorkable = new ArrowMasterWorkController();
        arrowWorkable.SetArrowWorkParameters(objectController, MasterRequest, Wood, Iron, transform, e_collider, e_objectPool, WorkRepeating, Repeating, WorkSlider);

        MasterRequest.WoodList.Clear();
        MasterRequest.IronList.Clear();
    }

    public void Update()
    {
        arrowWorkable.GetArrowWorkController();
        AnimatorWorkController();
    }

    void AnimatorWorkController()
    {
        if (Wood.Count == MasterRequest.WoodRequestNumber && Iron.Count == MasterRequest.IronRequestNumber)
        {
            transform.PlayAnim((int)ArrowAnim.WORK);
        }

        else
        {
            transform.PlayAnim((int)(ArrowAnim.IDLE));
        }
    }
    public void GetSelectFunch(ObjectType type, Transform objTransform)
    {
        switch (type)
        {
            case ObjectType.Iron:
                arrowWorkable.GetArrowIronAddListController(type, objTransform, e_objectPool,objectController);
                break;
            case ObjectType.Wood:
                arrowWorkable.GetArrowWoodAddListController(type, objTransform, e_objectPool,objectController);
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.GetInteractController(objectType, transform, GetSelectFunch);
    }

}


