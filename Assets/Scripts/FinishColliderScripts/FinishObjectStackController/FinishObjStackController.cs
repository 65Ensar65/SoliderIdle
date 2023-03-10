using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishObjStackController : IFinishStackable
{
    private List<Transform> stickmanList = new List<Transform>();
    private Transform[] objectArea;

    public void GetObjectStackController()
    {
    }

    public void SetObjectStackParameters(List<Transform> stickmanList, Transform[] objectArea)
    {
        this.stickmanList = stickmanList;
        this.objectArea = objectArea;

        for (int i = 0; i < stickmanList[0].childCount; i++)
        {
            objectArea[i] = stickmanList[0].GetChild(i);
        }
    }
}
