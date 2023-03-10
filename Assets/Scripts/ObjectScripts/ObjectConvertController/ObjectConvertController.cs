using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectConvertController : IObjectConvertable
{
    private ObjectType objectType;
    private Transform objectPos;
    private ObjectPool objectPool;
    public void GetObjectConvertController()
    {
        if (objectType == ObjectType.Iron)
        {
            objectPool.ReturnPoolObject(ObjectTag.Iron, objectPos.gameObject);
        }

        else if (objectType == ObjectType.Wood)
        {
            objectPool.ReturnPoolObject(ObjectTag.Wood, objectPos.gameObject);
        }
    }

    public void SetObjectConvertParameters(ObjectType objectType, Transform convertObjPos, ObjectPool objectPool)
    {
        this.objectType = objectType;
        this.objectPos = convertObjPos;
        this.objectPool = objectPool;
    }
}
