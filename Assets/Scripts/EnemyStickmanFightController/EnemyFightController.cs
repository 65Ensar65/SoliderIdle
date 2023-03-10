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

    [Title("Stickman Health System")]
    public float StickmanHealth;
    void Start()
    {
        enemyArrow = new EnemyArrowSystem();
        enemyArrow.SetEnemyArrowFightParameters(GameManager.Instance.WarPoint, transform, e_stickmanActive, e_objectPool, RepeatingTime, Repeating);

        enemySword = new EnemySwordSystem();
        enemySword.SetEnemySwordControllerParameters(e_stickmanActive, transform, GameManager.Instance.WarPoint, rushSpeed);

        healthtable = new HealthSystem();
        healthtable.SetHealthParameters(transform, e_objectPool, ObjectTag.Stickman);
    }

    void Update()
    {
        GetFightController();

        if (StickmanHealth <= 0)
        {
            transform.PlayAnim((int)EnemyAnim.FALL);
            InvokeRepeating(nameof(GetDeadController), 5, 5);
        }
    }

    void GetDeadController()
    {

        GameManager.Instance.EnemyList.Remove(transform);
        Destroy(gameObject);
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
                StickmanHealth -= 4f;
                action.Invoke(objectType, this.transform);
                break;
            case ObjectType.Arrow:
                StickmanHealth -= 20f;
                e_objectPool.ReturnPoolObject(ObjectTag.Arrow, transform.gameObject);
                action.Invoke(objectType, transform);
                break;
            default:
                break;
        }
    }
}
