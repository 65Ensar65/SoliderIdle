using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObjectSpawnable
{
    void GetWoodSpawnControllers();
    void GetIronSpawnControllers();
    void SetSpawnParameters(Transform spawnPos, ObjectPool objectPool, float repeatingTime, float repeating);
}