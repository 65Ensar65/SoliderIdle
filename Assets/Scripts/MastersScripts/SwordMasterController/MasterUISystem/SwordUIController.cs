using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordUIController : ISwordUIlable
{
    private Transform UIPos;
    private float animSpeed;
    public void GetSwordUIController()
    {
        UIPos.gameObject.SetActive(true);
        UIPos.DOMoveY(1f, animSpeed).OnComplete(
            delegate
            {
                UIPos.gameObject.SetActive(false);
                UIPos.DOMoveY(.1f, animSpeed);
            });
    }

    public void SetSwordUIParameters(Transform UIPos, float animSpeed)
    {
        this.UIPos = UIPos;
        this.animSpeed = animSpeed;
    }
}
