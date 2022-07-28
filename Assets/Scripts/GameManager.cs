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

    //[SerializeField] Animator puzzlePanelAnimator;
    //[SerializeField] Animator puzzlePanelObjectAnimator;

    // Update is called once per frame
    void Update()
    {
        if (PuzzleTracker >= 3) {
            PuzzleComplete();
        }
    }


    public void addPuzzleElement() 
    {
        //Tracks number of puzzle elements in correct location
        PuzzleTracker += 1;
        npcAnimator.GetComponent<Animator>().SetTrigger("ThumbsUp");
    }

    public void minusPuzzleElement() 
    {
        PuzzleTracker -= 1;
    }

    void PuzzleComplete() 
    {
        Debug.Log("Initial puzzle elements compelte");

        npcAnimator.GetComponent<Animator>().SetTrigger("Ending");
        shipAnimator.GetComponent<Animator>().SetTrigger("Ending");
        LightAnimator.GetComponent<Animator>().SetTrigger("Green");

        StartCoroutine(EndingTransition());
    }

    IEnumerator EndingTransition() 
    {
        yield return new WaitForSeconds(30);

        Debug.Log("Waited 10 Seconds ending");
        UIAnimator.GetComponent<Animator>().SetTrigger("FadeOut");

        SceneManager.LoadScene(0);
    }

}
