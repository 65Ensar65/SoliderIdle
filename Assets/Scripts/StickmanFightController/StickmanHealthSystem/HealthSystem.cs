using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : IHealthtable
{
    private Transform soliderPos;
    private ObjectPool objectPool;
    private ObjectTag objectTag;
    public void GetHealthController()
    {
        soliderPos.PlayAnim((int)PlayerAnim.FALL);
    }

    public void SetHealthParameters(Transform soliderPos, ObjectPool objectPool, ObjectTag objectTag)
    {
        this.soliderPos = soliderPos;
        this.objectPool = objectPool;
        this.objectTag = objectTag;
    }
}
