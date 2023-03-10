using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectConvertable
{
    void GetObjectConvertController();
    void SetObjectConvertParameters(ObjectType objectType, Transform convertObjPos, ObjectPool objectPool);
}

public interface IObjectable
{
    void GetSelectFunc(ObjectType type, Transform objTransform);
}

public interface IObjectStacklable
{
    void GetObjectStackController();
    void SetObjectStackParameters(Transform[] carList, Transform objectTransform, int areaIndex, float y_Pos);
}

public interface IWeaponizinglable
{
    void GetWeaponizingController();
    void SetWeaponizingParameters(StickmanController stickmanActive, Transform objectPos, ObjectType type);
}