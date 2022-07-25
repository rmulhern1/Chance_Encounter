using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGrabbable : OVRGrabbable
{
    protected override void Start()
    {
        base.Start();
    }

    public override void GrabEnd(Vector3 linearVelocity, Vector3 angularVelocity)
    {
        base.GrabEnd(linearVelocity, angularVelocity);
    }

}
