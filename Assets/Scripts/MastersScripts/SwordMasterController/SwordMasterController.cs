using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SwordMasterController : Base
{
    private ISwordWorkable swordWorkable;

    private Transform otherObject;

    [HideInInspector] public IMasterRequestable swordRequestable;
    [HideInInspector] public IGrandMoneyable grandMoneyable;

    [Title("Object Type Values")]
    public ObjectType objectType = ObjectType.SwordMaster;

    [Title("Sword UI Values")]
    public float UISpeed;
    public Image WorkSlider;

    [Title("Sword Request Values")]
    public List<GameObject> Wood = new List<GameObject>();
    public List<GameObject> Iron = new List<GameObject>();
    public MasterRequestSystem MasterRequest;
    public float WorkRepeating;
    public float Repeating;
    public float SpawnObjectRepeating;

    public MasterRequestSystem MasterRequestSystem;

    public void Start()
    {
        grandMoneyable = new SwordMasterMoneyController();
        grandMoneyable.SetGrandMoneyParameters(GameManager.Instance.MoneyText, GameManager.Instance.Money, GameManager.Instance.PlusesMoney);


        swordRequestable = new MasterRequestController();
        swordRequestable.SetSwordRequestParameters(MasterRequest.WoodList, MasterRequest.IronList, e_objectSpawn,
        MasterRequest.WoodRequestNumber, MasterRequest.IronRequestNumber, e_objectPool, 0, SpawnObjectRepeating, MasterRequest.IsWoodFree, MasterRequest.IsIronFree);

        swordWorkable = new SwordMasterWorkController();
        swordWorkable.SetSwordWorkParameters(swordMaster, MasterRequest, Wood, Iron, transform, e_collider, e_objectPool, WorkRepeating, Repeating,WorkSlider,e_upgradeController);

        MasterRequest.WoodList.Clear();
        MasterRequest.IronList.Clear();
    }

    private void Update()
    {
        swordWorkable.GetSwordWorkController();
        AnimatorWorkController();
    }

    void AnimatorWorkController()
    {
        if (Wood.Count == MasterRequest.WoodRequestNumber && Iron.Count == MasterRequest.IronRequestNumber)
        {
            transform.PlayAnim((int)SwordAnim.WORK);
        }

        else
        {
            transform.PlayAnim((int)(SwordAnim.IDLE));
        }
    }

    public void GetSelectFunch(ObjectType type, Transform objTransform)
    {
        switch (type)
        {
            case ObjectType.Iron:
                swordWorkable.GetSwordIronAddListController(type, objTransform, e_objectPool);
                break;
            case ObjectType.Wood:
                swordWorkable.GetSwordWoodAddListController(type, objTransform,e_objectPool);
                break;
            default:
                break;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        var interact = other.GetComponent<IInteract>();

        if (interact == null)
        {
            return;
        }
        interact.GetInteractController(objectType, transform, GetSelectFunch);
    }

}
