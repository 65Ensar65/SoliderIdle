using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IArrowFightable
{
    void GetFightController();
    void GetPointFightController();
    void SetFightParameters(Transform soliderPos, List<Transform> enemyArrowSolider, Transform enemySwordPoint, ObjectPool objectPool, float repeatingTime, float repeating);
}

public interface ISwordFightable
{
    void GetFightController();
    void SetFightParameters(Transform soliderPos, List<Transform> enemysolider, Transform enemySwordPoint, ObjectPool objectPool, float repeatingTime, float repeating, float rushSpeed);
}

public interface IHealthtable
{
    void GetHealthController();
    void SetHealthParameters(Transform soliderPos, ObjectPool objectPool, ObjectTag objectTag);
}
