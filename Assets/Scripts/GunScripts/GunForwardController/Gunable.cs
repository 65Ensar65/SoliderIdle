using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwordForwardable
{
    void GetForwardController();
    void GetForwardStopController();
    void SetForwardParameters(Rigidbody gunRigidbody, Transform gunPos, float gunForwardSpeed);
}