using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class AnimationColliderController : MonoBehaviour
{
    public Rig npcRigHead;
    public Rig npcRigTorso;

    [SerializeField] Collider playerElement;

    private void OnTriggerEnter(Collider collider)
    {
        //If the player collider enters the collider space, set rig weight on head and torso to 0
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player entered boundary");
            npcRigHead.weight = 0;
            npcRigTorso.weight = 0;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        //If the player collider leaves the collider space, set rig weight on head and torso to 1
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player left collider");
            npcRigHead.weight = 1;
            npcRigTorso.weight = 1;
        }
    }
}
