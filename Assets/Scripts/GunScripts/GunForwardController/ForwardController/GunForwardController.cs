using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunForwardController : ISwordForwardable
{
    private Rigidbody gunRigidbody;
    private Transform gunPos;
    private float gunForwardSpeed;
    public void GetForwardController()
    {
        gunRigidbody.velocity = -Vector3.forward * gunForwardSpeed;
    }

    public void GetForwardStopController()
    {
        gunRigidbody.velocity = Vector3.zero;
    }

    public void SetForwardParameters(Rigidbody gunRigidbody, Transform gunPos, float gunForwardSpeed)
    {
        this.gunRigidbody = gunRigidbody;
        this.gunPos = gunPos;
        this.gunForwardSpeed = gunForwardSpeed;
    }
}
