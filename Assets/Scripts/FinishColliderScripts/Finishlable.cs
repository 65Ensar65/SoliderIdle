using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFinishStackable
{
    void GetObjectStackController();
    void SetObjectStackParameters(List<Transform> carList, Transform[] objectArea);
}

public interface IInteract
{
    void GetInteractController(ObjectType type, Transform transform, Action<ObjectType,Transform> action);
}
