using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightStartController : Base
{
    void Update()
    {
        if (!GameManager.Instance.IsSpawn)
        {
           
            GameManager.Instance.GameCamera.DORotate(new Vector3(60, 90, 0), 3);
            GameManager.Instance.GameCamera.DOMoveY(12.28f, 3).OnComplete(delegate
            {
                if (GameManager.Instance.IsFree)
                {
                    GameManager.Instance.GetActiveFightButton();
                    for (int i = 0; i < e_stickmanActive.Stickmans.Count; i++)
                    {
                        e_stickmanActive.Stickmans[i].transform.PlayAnim((int)PlayerAnim.IDLE);
                    }
                }
            });
        }
    }
}
