using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanActiveController : IStickmanActivelable
{
    private ObjectPool objectPool;
    private List<Transform> stickmans = new List<Transform>();
    private Transform stickmanPos;
    Transform[] stickmanPosPoints;
    private int posIndex;
   
    public void GetPosPointController()
    {
       
        stickmans[posIndex].transform.PlayAnim((int)PlayerAnim.RUN);
        stickmans[posIndex].DOMove(stickmanPosPoints[posIndex].position, 3f).OnComplete(
            delegate
            {
                stickmans[posIndex - 1].transform.PlayAnim((int)PlayerAnim.IDLE);
                Debug.Log("Is index idle" + (posIndex - 1));
                GameManager.Instance.SpawnIndex++;

            });

        GameManager.Instance.SpawnIndex++;

        if (GameManager.Instance.SpawnIndex != GameManager.Instance.SpawnCapacity)
        {
            GameObject obj = objectPool.ActivePoolObject(ObjectTag.Stickman, stickmanPos);
            obj.transform.PlayAnim((int)PlayerAnim.RUN);
            stickmans.Add(obj.transform);
            obj.transform.DOMoveX(.3f, .5f).OnComplete(
                delegate
                {
                    obj.transform.PlayAnim((int)PlayerAnim.IDLE);
                });
            posIndex++;
        }
    }

    public void SetStickmanActiveParameters(ObjectPool objectPool, List<Transform> stickmans, Transform stickmanPos, Transform[] stickmanPosPoints, int posIndex, StickmanFightController stickmanFight)
    {
        this.objectPool = objectPool;
        this.stickmans = stickmans;
        this.stickmanPos = stickmanPos;
        this.stickmanPosPoints = stickmanPosPoints;
        this.posIndex = posIndex;

        GameObject obj = objectPool.ActivePoolObject(ObjectTag.Stickman, stickmanPos);
        stickmans.Add(obj.transform);
        obj.transform.PlayAnim((int)PlayerAnim.RUN);
        obj.transform.DOMoveX(.1f, .5f).OnComplete(
            delegate
            {
                obj.transform.PlayAnim((int)PlayerAnim.IDLE);
            });
    }
}
