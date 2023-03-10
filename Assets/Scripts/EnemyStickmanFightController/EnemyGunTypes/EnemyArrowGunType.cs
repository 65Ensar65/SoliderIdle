using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowGunType : Base, IInteract
{
    public ObjectType objectType;
    public void GetInteractController(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Stickman:
                if(objectType == ObjectType.Arrow)
                e_objectPool.ReturnPoolObject(ObjectTag.Misilline, gameObject);
                else
                action.Invoke(objectType, this.transform);
                break;
            default:
                break;
        }
    }
}
