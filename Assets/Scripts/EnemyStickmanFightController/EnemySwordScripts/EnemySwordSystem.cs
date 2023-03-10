using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwordSystem : IEnemySwordFightable
{
    private StickmanController stickmanController;
    private Transform soliderPos;
    private Transform warPoint;
    private float rushSpeed;
    public void GetEnemySwordController()
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

    public void SetEnemySwordControllerParameters(StickmanController stickmanController,Transform objPos, Transform warPoint, float rushSpeed)
    {
        this.stickmanController = stickmanController;
        this.soliderPos = objPos;
        this.warPoint = warPoint;
        this.rushSpeed = rushSpeed;
    }
}
