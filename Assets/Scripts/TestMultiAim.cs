using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;


public class TestMultiAim : MonoBehaviour
{
    public bool testBool = false;
    public Rig rig;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (testBool)
        {
            rig.weight = 0;
        }
    }

    void rigWeight(int newWeight) 
    {
        rig.weight = newWeight;
    }

}
