using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] int PuzzleTracker = 0;

    [SerializeField] GameObject npcAnimator;
    [SerializeField] GameObject shipAnimator;
    [SerializeField] GameObject UIAnimator;
    [SerializeField] GameObject LightAnimator;
    [SerializeField] GameObject EngineLightAnimator;
    [SerializeField] GameObject EngineLightAnimator2;

    //[SerializeField] Animator puzzlePanelAnimator;
    //[SerializeField] Animator puzzlePanelObjectAnimator;

    // Update is called once per frame
    void Update()
    {
        //Keeps track of the current puzzle score
        if (PuzzleTracker >= 3) {
            PuzzleComplete();
        }
    }


    public void addPuzzleElement() 
    {
        //Tracks number of puzzle elements in correct location and plays NPC thumbs-up animation
        PuzzleTracker += 1;
        npcAnimator.GetComponent<Animator>().SetTrigger("ThumbsUp");
    }


    void PuzzleComplete() 
    {
        //When all puzzle elements are complete, calls all necessary Animator triggers and begins ending transition
        Debug.Log("Initial puzzle elements compelte");

        npcAnimator.GetComponent<Animator>().SetTrigger("Ending");
        shipAnimator.GetComponent<Animator>().SetTrigger("Ending");
        LightAnimator.GetComponent<Animator>().SetTrigger("Green");
        EngineLightAnimator.GetComponent<Animator>().SetTrigger("Engine");
        EngineLightAnimator2.GetComponent<Animator>().SetTrigger("Engine");
        
        StartCoroutine(EndingTransition());
    }

    IEnumerator EndingTransition() 
    {
        //Delays scene transition for narrative to complete before loading to next scene
        yield return new WaitForSeconds(35);

        Debug.Log("Waited 35 Seconds ending");
        UIAnimator.GetComponent<Animator>().SetTrigger("EndingAnim");

        SceneManager.LoadScene(0);
    }

}
