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
        
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player entered boundary");
            npcRigHead.weight = 0;
            npcRigTorso.weight = 0;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Player left collider");
            npcRigHead.weight = 1;
            npcRigTorso.weight = 1;
        }
    }
}
