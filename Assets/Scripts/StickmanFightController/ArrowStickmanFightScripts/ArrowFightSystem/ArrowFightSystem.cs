using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFightSystem : IArrowFightable
{
    private Transform soliderPos;
    private List<Transform> enemyArrowSolider;
    private Transform enemySwordPoint;
    private ObjectPool objectPool;
    private float repeatingTime;
    private float repeating;
    public void GetFightController()
    {
        repeating += Time.deltaTime;

        if (repeating >= repeatingTime)
        {
            var enemysoliderPos = enemyArrowSolider[Random.Range(0, enemyArrowSolider.Count)];
            soliderPos.LookAt(enemysoliderPos.position);
            GameObject obj = objectPool.ActivePoolObject(ObjectTag.Misilline, soliderPos.GetChild(1));
            obj.transform.LookAt(enemysoliderPos.position);
            obj.transform.DOJump(enemysoliderPos.GetChild(1).position, .5f, 1, .5f);
            soliderPos.transform.PlayAnim((int)PlayerAnim.ARROWSHOOT);
            repeating = 0;
        }

    }

    public void GetPointFightController()
    {
        repeating += Time.deltaTime;

        if (repeating >= repeatingTime)
        {
            var enemysoliderPos = enemySwordPoint;
            soliderPos.LookAt(enemysoliderPos.position);
            GameObject obj = objectPool.ActivePoolObject(ObjectTag.Misilline, soliderPos.GetChild(1));
            obj.transform.LookAt(enemysoliderPos.position);
            obj.transform.DOJump(enemysoliderPos.position, .5f, 1, .5f);
            soliderPos.transform.PlayAnim((int)PlayerAnim.ARROWSHOOT);
            repeating = 0;
        }
    }

    public void SetFightParameters(Transform soliderPos, List<Transform> enemyArrowSolider, Transform enemySwordPoint, ObjectPool objectPool, float repeatingTime, float repeating)
    {
        this.soliderPos = soliderPos;
        this.enemyArrowSolider = enemyArrowSolider;
        this.enemySwordPoint = enemySwordPoint;
        this.objectPool = objectPool;
        this.repeatingTime = repeatingTime;
        this.repeating = repeating;
    }
}
