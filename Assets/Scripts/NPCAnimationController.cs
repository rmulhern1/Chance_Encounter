using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations.Rigging;

public class NPCAnimationController : MonoBehaviour
{
    [SerializeField] GameObject npcAnimator;
    [SerializeField] GameObject[] hologramSlides;
    [SerializeField] GameObject UIAnimator;

    [SerializeField] int currentSlide;
    [SerializeField] bool inputA;

    bool crashHologram = true;
    bool repairHologram = false;
    bool decisionHologram = false;

    public Rig npcRigHead;
    public Rig npcRigTorso;

    public bool rigWeightAdd;
    public bool isStationary = false;
    
        // Start is called before the first frame update
    void Start()
    {
        //Sets current slide in array to 0
        currentSlide = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Listens for when rigWeightAdd is true and chagnes weights accordingly
        if (rigWeightAdd)
        {
            npcRigHead.weight = 1;
            npcRigTorso.weight = 1;
        }
        //Listens for when rigWeightAdd is false and chagnes weights accordingly
        else if (!rigWeightAdd) {
            npcRigHead.weight = 0;
            npcRigTorso.weight = 0;
        }

        //Calls CrashHologram() if crashHologram boolean is set to true
        if (crashHologram)
        {
            CrashHologram();
        }

        //Calls RepairHologram() if repairHologram boolean is set to true
        if (repairHologram) {
            RepairHologram();
        }

        //Calls DecisionHologram() if decisionHologram is set to tru
        if (decisionHologram) {
            DecisionHologram();
        }
    }

    void RemoveRigWeight() 
    {
        //Updates rigWeightAdd boolean when called from animation event
        Debug.Log("Called remove rig weight");
        rigWeightAdd = false;
        //npcRigHead.weight = 0;
        //npcRigTorso.weight = 0;
    }

    void AddRigWeight() 
    {
        //Updates rigWeightAdd boolean when called from animation event
        Debug.Log("Called add rig weight");
        rigWeightAdd = true;
        //npcRigHead.weight = 1;
        //npcRigTorso.weight = 1;
    }

    //If the currentSlide is larger that 11, set Animator Trigger and update booleans
    //If "A" button is pressed on Oculus controller then set current object to false, and set next object in array to true
    //Releases button press


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
        //If "A" button is pressed on Oculus controller then set current object to false, and set next object in array to true
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
            currentSlide += 1;
            hologramSlides[currentSlide - 1].SetActive(false);
            hologramSlides[currentSlide].SetActive(true);

            //If the currentSlide is larger that 16, set Animator Trigger and update booleans
            if (currentSlide >= 16)
            {
                hologramSlides[currentSlide].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetTrigger("AfterRepairHologram");
                repairHologram = false;
                decisionHologram = true;
            }

            //Releases button press
            inputA = !inputA;
        }
    }

    void DecisionHologram() 
    {
        //If "A" button is pressed on Oculus controller then set current object to false, and set next object in array to true
        Debug.Log("Waiting for user to make decision");
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            currentSlide += 1;
            hologramSlides[currentSlide].SetActive(true);
            hologramSlides[currentSlide - 1].SetActive(false);

            //If the currentSlide is larger that 17, set Animator Trigger and update booleans
            if (currentSlide >= 17)
            {
                Debug.Log("A button pressed");
                //npcAnimator.GetComponent<Animator>().SetBool("Decision", true);
                //Checks if scene is stationary, and sets appropriate trigger in Animator
                if (isStationary)
                {
                    npcAnimator.GetComponent<Animator>().SetTrigger("StationaryDecisionmade");
                }
                else
                {
                    npcAnimator.GetComponent<Animator>().SetTrigger("DecisionMade");
                }
            }

            //Releases button press
            inputA = !inputA;
        }
    }

    void StationaryTransition()
    {
        //Called from Animation event to change stationary scene
        Debug.Log("Stationary Transition Transition Called");
        //UIAnimator.GetComponent<Animator>().SetTrigger("MainFadeOut");
        SceneManager.LoadScene(2);
    }
}
