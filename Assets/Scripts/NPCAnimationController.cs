using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class NPCAnimationController : MonoBehaviour
{
    [SerializeField] GameObject npcAnimator;
    [SerializeField] GameObject[] hologramSlides;

    [SerializeField] int currentSlide;
    [SerializeField] bool inputA;

    bool crashHologram = true;
    bool repairHologram = false;
    bool decisionHologram = false;

    public Rig npcRigHead;
    public Rig npcRigTorso;

    public bool rigWeightAdd;

    // Start is called before the first frame update
    void Start()
    {
        currentSlide = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigWeightAdd)
        {
            npcRigHead.weight = 1;
            npcRigTorso.weight = 1;
        }
        else if (!rigWeightAdd) {
            npcRigHead.weight = 0;
            npcRigTorso.weight = 0;
        }

        if (crashHologram)
        {
            CrashHologram();
        }

        if (repairHologram) {
            RepairHologram();
        }

        if (decisionHologram) {
            DecisionHologram();
        }
    }

    void RemoveRigWeight() 
    {
        Debug.Log("Called remove rig weight");
        rigWeightAdd = false;
        //npcRigHead.weight = 0;
        //npcRigTorso.weight = 0;
    }

    void AddRigWeight() 
    {
        Debug.Log("Called add rig weight");
        rigWeightAdd = true;
        //npcRigHead.weight = 1;
        //npcRigTorso.weight = 1;
    }

    void CrashHologram() 
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
            currentSlide += 1;
            hologramSlides[currentSlide - 1].SetActive(false);
            hologramSlides[currentSlide].SetActive(true);

            if (currentSlide >=11)
            {
                hologramSlides[currentSlide].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetTrigger("AfterCrashHologram");
                crashHologram = false;
                repairHologram = true;
            }

            inputA = !inputA;
        }
    }

    void RepairHologram() 
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
            currentSlide += 1;
            hologramSlides[currentSlide - 1].SetActive(false);
            hologramSlides[currentSlide].SetActive(true);

            if (currentSlide >= 16)
            {
                //hologramSlides[currentSlide].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetTrigger("AfterRepairHologram");
                repairHologram = false;
                decisionHologram = true;
            }

            inputA = !inputA;
        }
    }

    void DecisionHologram() 
    {
        Debug.Log("Waiting for user to make decision");
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            currentSlide += 1;
            hologramSlides[currentSlide].SetActive(true);
            hologramSlides[currentSlide - 1].SetActive(false);

            if (currentSlide >= 17)
            {
                Debug.Log("A button pressed");
                //npcAnimator.GetComponent<Animator>().SetBool("Decision", true);
                npcAnimator.GetComponent<Animator>().SetTrigger("DecisionMade");
            }
            inputA = !inputA;

        }
    }

}
