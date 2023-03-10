using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGunForwadable
{
    void GetGunForwardController();
    void SetGunForwardParameters(Rigidbody gunRigidbody, Transform gunPos, float forwardSpeed);
}