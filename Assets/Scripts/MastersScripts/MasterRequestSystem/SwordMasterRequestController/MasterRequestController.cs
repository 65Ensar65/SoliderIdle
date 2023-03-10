using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterRequestController : IMasterRequestable
{
    private List<GameObject> woodList = new List<GameObject>();
    private List<GameObject> ironList = new List<GameObject>();
    private ObjectSpawnController spawnController;
    private int woodRequestNumber;
    private int ironRequestNumber;
    private ObjectPool objectPool;
    private float repeatTime;
    private float repeating;
    private bool isWoodFree;
    private bool isIronFree;
    public void GetSwordRequestController()
    {
        if (GameManager.Instance.SpawnIndex != GameManager.Instance.SpawnCapacity)
        {
            if (woodList.Count < woodRequestNumber && isWoodFree)
            {
                repeatTime += Time.deltaTime;

                if (repeatTime >= repeating)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Wood, spawnController.transform);
                    woodList.Add(obj);

                    if (woodList.Count == woodRequestNumber)
                    {
                        isWoodFree = false;
                    }

                    isWoodFree = true;
                    repeatTime = 0;
                }
            }

            if (ironList.Count < ironRequestNumber && isIronFree)
            {
                repeatTime += Time.deltaTime;

                if (repeatTime >= repeating)
                {
                    GameObject obj = objectPool.ActivePoolObject(ObjectTag.Iron, spawnController.transform);
                    ironList.Add(obj);

                    if (ironList.Count == ironRequestNumber)
                    {
                        isIronFree = false;
                    }

                    isIronFree = true;
                    repeatTime = 0;
                }
            }
        }
    }

    public void SwordRequestWoodCreate()
    {
        for (int i = 0; i < ironList.Count; i++)
        {
            ironList.Remove(woodList[i]);
        }

        for (int i = 0; i < woodList.Count; i++)
        {
            woodList.Remove(woodList[i]);
        }
    }

    public void SetSwordRequestParameters(List<GameObject> woodList, List<GameObject> ironList, ObjectSpawnController spawnController, int woodRequestNumber, int ironRequestNumber, ObjectPool objectPool, float repeatTime, float repeating, bool isWoodFree, bool isIronFree)
    {
        this.woodList = woodList;
        this.ironList = ironList;
        this.spawnController = spawnController;
        this.woodRequestNumber = woodRequestNumber;
        this.ironRequestNumber = ironRequestNumber;
        this.objectPool = objectPool;
        this.repeatTime = repeatTime;
        this.repeating = repeating;
        this.isWoodFree = isWoodFree;
        this.isIronFree = isIronFree;
    }
}
