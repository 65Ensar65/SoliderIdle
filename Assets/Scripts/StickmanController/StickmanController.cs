using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickmanController : Base
{
    public IStickmanActivelable stickmanActivelable;
    public Transform StickmanHand;

    [Title("Stickman Pos Values")]
    public List<Transform> Stickmans = new List<Transform>();
    [SerializeField] Transform[] StickmanPosPoints = new Transform[100];
    public int PosIndex;
    void Start()
    {
        stickmanActivelable = new StickmanActiveController();
        stickmanActivelable.SetStickmanActiveParameters(e_objectPool, Stickmans, transform, StickmanPosPoints, PosIndex,stickmanFight);
    }
}
