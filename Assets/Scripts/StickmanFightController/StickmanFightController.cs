using DG.Tweening;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanFightController : Base
{
    private IArrowFightable arrowFightable;
    private ISwordFightable swordFightable;
    private IHealthtable healthtable;

    private ObjectType objectType = ObjectType.Stickman;

    [Title("Arrow Fight Values")]
    public float RepeatingTime;
    public float Repeating;
    public Transform StickmanHand;
    public float rushSpeed;

    [Title("Stickman Health System")]
    public float StickmanHealth;

    [Title("Stickman Ragdoll System")]
    public Rigidbody[] RagdollRigidbody = new Rigidbody[15];

    void Start()
    {
        arrowFightable = new ArrowFightSystem();
        arrowFightable.SetFightParameters(transform, GameManager.Instance.EnemyList, GameManager.Instance.WarPoint, e_objectPool, RepeatingTime, Repeating);
        transform.rotation = Quaternion.Euler(0, 90, 0);

        swordFightable = new SwordFightSystem();
        swordFightable.SetFightParameters(transform, GameManager.Instance.EnemyList, GameManager.Instance.WarPoint, e_objectPool, 5, Repeating, rushSpeed);

        healthtable = new HealthSystem();
        healthtable.SetHealthParameters(transform, e_objectPool, ObjectTag.Stickman);
    }

    void Update()
    {
        if (GameManager.Instance.IsFight)
        {
            if (StickmanHand.GetChild(1).GetComponent<GunController>().GunType == ObjectType.Arrow)
            {
                if (GameManager.Instance.EnemyList.Count != 0)
                {
                    arrowFightable.GetFightController();
                    StickmanHand.GetChild(1).transform.DOLocalRotate(new Vector3(17.5f, 90, 112.5f), .1f);
                }

                else
                {
                    arrowFightable.GetPointFightController();
                    StickmanHand.GetChild(1).transform.DOLocalRotate(new Vector3(17.5f, 90, 112.5f), .1f);
                }
            }

            if (StickmanHand.GetChild(1).GetComponent<GunController>().GunType == ObjectType.Sword)
            {
                swordFightable.GetFightController();
            }
        }

        if (StickmanHealth <= 0)
        {
            for (int i = 0; i < RagdollRigidbody.Length; i++)
            {
                RagdollRigidbody[i].GetComponent<Rigidbody>();
                RagdollRigidbody[i].isKinematic = false;
            }
            e_stickmanActive.Stickmans.Remove(transform);
            healthtable.GetHealthController();
        }

        if (GameManager.Instance.EnemyList.Count <= 0)
        {
            GameManager.Instance.IsFight = false;
        }
    }
    void GetSelectFunch(ObjectType objectType, Transform transform)
    {
        switch (objectType)
        {
            case ObjectType.EnemySword:
                Debug.Log("EnemySwordHit");
                StickmanHealth -= 5;
                break;
            case ObjectType.EnemyArrow:
                e_objectPool.ReturnPoolObject(ObjectTag.EnemyMisilline, transform.gameObject);
                Debug.Log("Enemy arrow Hit");
                StickmanHealth -=4;
                break;
            default:
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<IInteract>()?.GetInteractController(objectType, transform, GetSelectFunch);
    }
}

