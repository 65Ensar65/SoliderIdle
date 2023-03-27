using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFightController : Base,IInteract
{
    private ObjectType objectType = ObjectType.Enemy;

    private IEnemyArrowFightable enemyArrow;
    private IEnemySwordFightable enemySword;
    private IHealthtable healthtable;

    [Title("Arrow Fight Values")]
    public Transform EnemyHand;
    public float RepeatingTime;
    public float Repeating;
    public float rushSpeed;
    public float WarPos;
    public float RushTime;
    public float RushRepeatingTime;

    [Title("Stickman Health System")]
    public float StickmanHealth;
    public Rigidbody[] RagdollRigibody;
    void Start()
    {
        enemyArrow = new EnemyArrowSystem();
        enemyArrow.SetEnemyArrowFightParameters(GameManager.Instance.WarPoint, transform, e_stickmanActive, e_objectPool, RepeatingTime, Repeating);

        enemySword = new EnemySwordSystem();
        enemySword.SetEnemySwordControllerParameters(e_stickmanActive, transform, GameManager.Instance.WarPoint, rushSpeed,WarPos);

        healthtable = new HealthSystem();
        healthtable.SetHealthParameters(transform, e_objectPool, ObjectTag.Stickman);
    }

    void Update()
    {
        GetFightController();

        if (StickmanHealth <= 0)
        {
            GameManager.Instance.EnemyList.Remove(transform);
            GetComponent<CapsuleCollider>().enabled = false;

            for (int i = 0; i < RagdollRigibody.Length; i++)
            {
                RagdollRigibody[i].GetComponent<Rigidbody>();
                RagdollRigibody[i].isKinematic = false;
            }
            e_animator.enabled = false;
            //transform.PlayAnim((int)EnemyAnim.FALL);
        }


        if (e_stickmanActive.Stickmans.Count <= 0)
        {
            GameManager.Instance.IsFight = false;
        }

        RushTime += Time.deltaTime;

        if (RushTime >= RushRepeatingTime)
        {
            RushTime = 0;
            WarPos -= 0.1f;
        }
    }

    void GetFightController()
    {
        if (GameManager.Instance.IsFight)
        {
            if (EnemyHand.GetChild(1).GetComponent<EnemyArrowGunType>().objectType == ObjectType.EnemyArrow)
            {
                if (e_stickmanActive.Stickmans.Count != 0)
                {
                    enemyArrow.GetEnemyArrowFightController();
                }

                else
                {
                    enemyArrow.GetEnemyArrowPointFightController();
                }
            }

            if (EnemyHand.GetChild(1).GetComponent<EnemyArrowGunType>().objectType == ObjectType.EnemySword)
            {
                if (e_stickmanActive.Stickmans.Count != 0)
                {
                    enemySword.GetEnemySwordController();
                }
            }
        }
    }

    public void GetInteractController(ObjectType type, Transform transform, Action<ObjectType, Transform> action)
    {
        switch (type)
        {
            case ObjectType.Sword:
                StickmanHealth -= 6f;
                action.Invoke(objectType, this.transform);
                break;
            case ObjectType.Arrow:
                StickmanHealth -= 10f;
                e_objectPool.ReturnPoolObject(ObjectTag.Arrow, transform.gameObject);
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
