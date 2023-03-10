using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowGunType : Base
{
    private ObjectType objectType = ObjectType.Arrow;

    void GetSelectFunh(ObjectType type, Transform transform)
    {
        switch (type)
        {
            case ObjectType.Enemy:
                e_objectPool.ReturnPoolObject(ObjectTag.Misilline, gameObject);
                break;
            default:
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.GetInteractController(objectType, transform, GetSelectFunh);
    }
}
