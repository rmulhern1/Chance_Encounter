using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class VRMap
{ 
    public Transform vrTarget;
    public Transform rigTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    //Updates the position and rotation of chosen object to reflect that of the VR rig
    public void Map() 
    {
        rigTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class VRRig : MonoBehaviour
{
    public float turnSmoothness;

    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;
    public Transform headConstraint;
    public Vector3 headbodyOffset;


    // Start is called before the first frame update
    void Start()
    {
        headbodyOffset = transform.position - headConstraint.position;    
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Transforms position of the object to align with VR movement with smoothing
        transform.position = headConstraint.position + headbodyOffset;
        transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

        //Maps the head and hand objects
        head.Map();
        leftHand.Map();
        rightHand.Map();
    }
}
