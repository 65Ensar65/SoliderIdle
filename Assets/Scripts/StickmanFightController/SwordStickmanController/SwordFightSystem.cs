using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordFightSystem : ISwordFightable
{
    private Transform soliderPos;
    private List<Transform> soliders;
    private Transform warPoint;
    private ObjectPool objectPool;
    private float repeatingTime;
    private float repeating;
    private float rushSpeed;
    public void GetFightController()
    {
        var enemysoliderPos = warPoint;
        soliderPos.LookAt(enemysoliderPos.position);
        soliderPos.transform.position = Vector3.Lerp(soliderPos.transform.position, enemysoliderPos.position, rushSpeed * Time.deltaTime);
        soliderPos.transform.PlayAnim((int)PlayerAnim.RUN);

        var magniPos = soliderPos.position - enemysoliderPos.position;

        if (magniPos.magnitude < 1f)
        {
            soliderPos.transform.PlayAnim((int)PlayerAnim.SWORDSHOOT);
            rushSpeed = 0;
        }
    }

    public void SetFightParameters(Transform soliderPos, List<Transform> enemysolider, Transform enemySwordPoint, ObjectPool objectPool, float repeatingTime, float repeating,  float rushSpeed)
    {
        this.soliderPos = soliderPos;
        this.soliders = enemysolider;
        this.warPoint = enemySwordPoint;
        this.objectPool = objectPool;
        this.repeatingTime = repeatingTime;
        this.repeating = repeating;
        this.rushSpeed = rushSpeed;
    }
}
