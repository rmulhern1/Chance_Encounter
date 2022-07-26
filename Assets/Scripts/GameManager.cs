using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int itemProximity = 0;
    [SerializeField] bool isDone;
    [SerializeField] int puzzleTracker = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (itemProximity > 1 && isDone != true) {
            itemPositions();
            isDone = true;
        }

        if (puzzleTracker >= 3) {
            Debug.Log("All puzzle elements compelte");
            puzzleComplete();
        }
    }

    void itemPositions() 
    { 
        
    }

    void puzzleComplete() 
    {
        //Play character animation
        //Play ship animation
        //Play UI animation
        //Return to main menu
    }
}
