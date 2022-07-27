using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAnimationController : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] GameObject[] hologramSlides;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //OnButtonPressDown (Controller A), currentSlide += 1
    //OnButtonPressDown (Controller B), currentSlide -= 1
    //if (currentslide > (total), hide hologram slides and resume animations/settrigger)
    
}
