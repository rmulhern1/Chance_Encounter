using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    [SerializeField] GameObject npcAnimator;
    [SerializeField] GameObject[] hologramSlides;

    [SerializeField] int currentSlide;

    // Start is called before the first frame update
    void Start()
    {
        currentSlide = -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Button.One))
        {
            Debug.Log("A button pressed");
            currentSlide += 1;
            hologramSlides[currentSlide - 1].SetActive(false);
            hologramSlides[currentSlide].SetActive(true);

            if (currentSlide > 3) {
                hologramSlides[currentSlide].SetActive(false);
                npcAnimator.GetComponent<Animator>().SetTrigger("AfterHologram");
            }
        }
    }


    //OnButtonPressDown (Controller A), currentSlide += 1
    //OnButtonPressDown (Controller B), currentSlide -= 1
    //if (currentslide > (total), hide hologram slides and resume animations/settrigger)
    
}
