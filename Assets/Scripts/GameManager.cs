using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int itemProximity = 0;
    [SerializeField] bool isDone;
    [SerializeField] int puzzleTracker = 0;

    Animator npcAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (itemProximity > 1 && isDone != true) {
            itemPositions();
            isDone = true;
        }*/

        if (puzzleTracker >= 3) {
            puzzleComplete();
        }
    }


    public void addPuzzleElement() 
    {
        //Tracks number of puzzle elements in correct location
        puzzleTracker += 1;
    }

    public void minusPuzzleElement() 
    {
        puzzleTracker -= 1;
    }

    /*void itemPositions() 
    { 
        
    }*/

    void puzzleComplete() 
    {
        Debug.Log("All puzzle elements compelte");
        //Play character animation
        //Play ship animation
        //Play UI animation
        //Return to main menu
        //npcAnimator.Play("Animation");
    }
}
