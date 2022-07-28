using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    [SerializeField] GameObject npcAnimator;
    [SerializeField] GameObject[] hologramSlides;

    [SerializeField] int currentSlide;
    [SerializeField] bool inputA;

    bool crashHologram = true;
    bool repairHologram = false;
    bool decisionHologram = false;


    // Start is called before the first frame update
    void Start()
    {
        currentSlide = -1;
    }

    // Update is called once per frame
    void Update()
    {
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

    void CrashHologram() 
    {
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
            currentSlide += 1;
            hologramSlides[currentSlide - 1].SetActive(false);
            hologramSlides[currentSlide].SetActive(true);

            if (currentSlide > 12)
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

            if (currentSlide > 17)
            {
                hologramSlides[currentSlide].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetTrigger("AfterRepairHologram");
                repairHologram = false;
            }

            inputA = !inputA;
        }
    }

    void DecisionHologram() 
    {
        Debug.Log("Waiting for user to make decision");
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            if (currentSlide > 18)
            {
                Debug.Log("A button pressed");
                currentSlide += 1;
                hologramSlides[currentSlide - 1].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetBool("Decision", true);
            }
            inputA = !inputA;

        }
    }

}
