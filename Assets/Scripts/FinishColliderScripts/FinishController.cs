using DG.Tweening;
using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Reflection;

public class FinishController : Base,IInteract
{
    public IFinishStackable finishStackable;
    private ObjectType objectType = ObjectType.TableFinish;

    public void GetInteractController(ObjectType type, Transform objTransform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Sword:
                Debug.Log(action.GetMethodInfo().Name);
                action.Invoke(objectType, objTransform);
                break;
            case ObjectType.Arrow:
                Debug.Log(action.GetMethodInfo().Name);
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
