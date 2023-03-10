using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Master Request" , menuName ="Master RequestObjects")]
public class MasterRequestSystem : ScriptableObject
{
    public List<GameObject> WoodList = new List<GameObject>();
    public List<GameObject> IronList = new List<GameObject>();
    public ObjectSpawnController SpawnController;
    public int WoodRequestNumber;
    public int IronRequestNumber;
    public bool IsWoodFree;
    public bool IsIronFree;
}
