using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MastersSystem : Base
{
     public bool IsSpawn = true;

    [SerializeField] List<Transform> Masters = new List<Transform>();

    [SerializeField] int index;

    [SerializeField] float Repeat;
    [SerializeField] float RepeatTime;
    [SerializeField] bool IsFree;

    void Update()
    {
        ObjectSortingSpawn();
    }

    void ObjectSortingSpawn()
    {
        if (GameManager.Instance.IsSpawn)
        {
            if (index == 0)
            {
                for (int i = 0; i < swordMaster.MasterRequest.IronRequestNumber + swordMaster.MasterRequest.WoodRequestNumber; i++)
                {
                    Masters[index].GetComponent<SwordMasterController>().swordRequestable.GetSwordRequestController();
                }
            }

            if (index == 1)
            {
                for (int i = 0; i < arrowMaster.MasterRequest.IronRequestNumber + arrowMaster.MasterRequest.WoodRequestNumber; i++)
                {
                    Masters[index].GetComponent<ArrowMasterController>().swordRequestable.GetSwordRequestController();
                }
            }

            Repeat += Time.deltaTime;

            if (Repeat > RepeatTime)
            {
                index++;

                if (index == Masters.Count)
                {
                    index = 0;
                }
                Repeat = 0;
            }
        }

        if (GameManager.Instance.SpawnIndex == GameManager.Instance.SpawnCapacity)
        {
            for (int i = 0; i < GameManager.Instance.GunList.Count; i++)
            {
                Destroy(GameManager.Instance.GunList[i]);
            }

            GameManager.Instance.IsSpawn = false;
            GameManager.Instance.Masters.SetActive(false);
            GameManager.Instance.LevelText.SetActive(false);
        }
    }
}
