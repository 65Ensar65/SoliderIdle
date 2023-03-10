using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : IObjectSpawnable
{
    private Transform spawnPos;
    private ObjectPool objectPool;
    private float repeatingTime;
    private float repeating;
    public void GetWoodSpawnControllers()
    {
        objectPool.ActivePoolObject(ObjectTag.Arrow, spawnPos);
    }

    public void GetIronSpawnControllers()
    {
        objectPool.ActivePoolObject(ObjectTag.Iron, spawnPos);
    }

    public void SetSpawnParameters(Transform spawnPos, ObjectPool objectPool, float repeatingTime, float repeating)
    {
        this.spawnPos = spawnPos;
        this.objectPool = objectPool;
        this.repeatingTime = repeatingTime;
        this.repeating = repeating;
    }
}
