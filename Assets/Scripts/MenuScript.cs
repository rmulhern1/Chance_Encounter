using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject ship;
    [SerializeField] GameObject fadeOut;

    public void Start_Btn()
    {
        //Start button sets menu active to false from inspector
        //Play ship animation with animation event to trigger scene change
        ship.GetComponent<Animator>().SetTrigger("ShipTrigger");
        fadeOut.GetComponent<Animator>().SetTrigger("MenuFadeOut");
        Debug.Log("Start Button pushed");
    }

    public void Quit_Btn()
    {
        //Quits application on button press
        Debug.Log("Quit Button pushed");
        Application.Quit();
    }

    public void About_Btn()
    {
        //Inspector enables and disables necessary panels and UI items
        Debug.Log("About button pushed");
    }

    public void Controls_Btn()
    {
        //Inspector enables and disables necessary panels and UI items
        Debug.Log("Controls button pushed");
    }

}
