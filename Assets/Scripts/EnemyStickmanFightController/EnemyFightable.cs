using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemyArrowFightable
{
    void GetEnemyArrowFightController();
    void GetEnemyArrowPointFightController();
    void SetEnemyArrowFightParameters(Transform warPoint, Transform objPos, StickmanController stickmanController, ObjectPool objectPool, float repeatingTime, float repeating);
}

public interface IEnemySwordFightable
{
    void GetEnemySwordController();
    void SetEnemySwordControllerParameters(StickmanController stickmanController,Transform objPos, Transform warPoint, float rushSpeed, float warPos);
}