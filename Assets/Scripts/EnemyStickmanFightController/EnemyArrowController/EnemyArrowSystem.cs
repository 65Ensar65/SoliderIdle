using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArrowSystem : IEnemyArrowFightable
{
    private Transform warPoint;
    private Transform objPos;
    private StickmanController stickmanController;
    private ObjectPool objectPool;
    private float repeatingTime;
    private float repeating;
    public void GetEnemyArrowFightController()
    {
        repeating += Time.deltaTime;

        if (repeating >= repeatingTime)
        {
            var enemysoliderPos = stickmanController.Stickmans[Random.Range(0,stickmanController.Stickmans.Count)];
            objPos.LookAt(enemysoliderPos.localPosition);
            GameObject obj = objectPool.ActivePoolObject(ObjectTag.EnemyMisilline, objPos.GetChild(1));
            obj.transform.LookAt(enemysoliderPos.localPosition);
            obj.transform.DOLocalJump(enemysoliderPos.GetChild(0).position, .5f, 1, .5f);
            objPos.transform.PlayAnim((int)EnemyAnim.ARROWSHOOT);
            repeating = 0;
        }
    }

    public void GetEnemyArrowPointFightController()
    {
        repeating += Time.deltaTime;

        if (repeating >= repeatingTime)
        {
            var enemysoliderPos = warPoint;
            objPos.LookAt(enemysoliderPos.localPosition);
            GameObject obj = objectPool.ActivePoolObject(ObjectTag.EnemyMisilline, objPos.GetChild(1));
            obj.transform.LookAt(enemysoliderPos.localPosition);
            obj.transform.DOLocalJump(enemysoliderPos.localPosition, .5f, 1, .5f);
            objPos.transform.PlayAnim((int)EnemyAnim.ARROWSHOOT);
            repeating = 0;
        }
    }

    public void SetEnemyArrowFightParameters(Transform warPoint, Transform objPos, StickmanController stickmanController, ObjectPool objectPool, float repeatingTime, float repeating)
    {
        this.warPoint = warPoint;
        this.objPos = objPos;
        this.stickmanController = stickmanController;
        this.objectPool = objectPool;
        this.repeatingTime = repeatingTime;
        this.repeating = repeating;
    }
}
