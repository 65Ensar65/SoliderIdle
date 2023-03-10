using PathCreation.Examples;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectSpawnController : Base
{
    [HideInInspector] public IObjectSpawnable ironSpawnable;

    [Title("Iron Spawn Values")]
    [SerializeField] public float Repeating;
    [SerializeField] public float RepeatingTime;
    void Start()
    {
        ironSpawnable = new ObjectSpawn();
        ironSpawnable.SetSpawnParameters(transform, e_objectPool, RepeatingTime, Repeating);
    }
}
