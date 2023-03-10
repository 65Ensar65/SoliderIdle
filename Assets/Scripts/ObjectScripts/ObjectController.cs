using DG.Tweening;
using PathCreation.Examples;
using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController : Base,IInteract
{
    private IObjectConvertable objectConvertable;

    [Title("Object Type Values")]
    [SerializeField] public ObjectType ObjectType;

    void Start()
    {
        objectConvertable = new ObjectConvertController();

        objectConvertable.SetObjectConvertParameters(ObjectType, transform, e_objectPool);
    }

    public void GetInteractController(ObjectType type, Transform objTransform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.SwordMaster:
                action.Invoke(ObjectType, transform);
                break;
            case ObjectType.ArrowMaster:
                action.Invoke(ObjectType, transform);
                break;
            default:
                break;
        }
    }

}
