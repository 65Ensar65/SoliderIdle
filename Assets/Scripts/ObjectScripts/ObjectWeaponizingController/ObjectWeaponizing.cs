using PathCreation.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectWeaponizing : IWeaponizinglable
{
    private StickmanController activeController;
    private Transform objectPos;
    private ObjectType objectType;
    public void GetWeaponizingController()
    {
        GameManager.Instance.GunList.Remove(objectPos.gameObject);

        objectPos.SetParent(activeController.Stickmans[GameManager.Instance.PosIndex].GetComponent<StickmanFightController>().StickmanHand);

        objectPos.DOMove(activeController.Stickmans[GameManager.Instance.PosIndex].GetComponent<StickmanFightController>().StickmanHand.position, 0.5f).OnComplete(
            delegate
            {
                if (objectType == ObjectType.Sword)
                {
                    objectPos.transform.DOLocalRotate(new Vector3(0, -70, 0), .1f);
                    Debug.Log("Sword Hand Pos");
                }

                else if (objectType == ObjectType.Arrow)
                {
                    objectPos.transform.DORotate(new Vector3(0, -110, -40), .1f);
                }

                if (GameManager.Instance.IsSpawn == true)
                {
                    activeController.stickmanActivelable.GetPosPointController();
                }
            });

        GameManager.Instance.PosIndex++;
    }

    public void SetWeaponizingParameters(StickmanController stickmanActive, Transform objectPos, ObjectType type)
    {
        this.activeController = stickmanActive;
        this.objectPos = objectPos;
        this.objectType = type;
    }
}
