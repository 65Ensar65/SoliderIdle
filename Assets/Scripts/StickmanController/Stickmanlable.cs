using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStickmanActivelable
{
    void GetPosPointController();
    void SetStickmanActiveParameters(ObjectPool objectPool, List<Transform> stickmans, Transform stickmanPos, Transform[] stickmanPosPoints, int posIndex, StickmanFightController stickmanFight);
}