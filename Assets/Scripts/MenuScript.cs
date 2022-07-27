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

        //SceneManager.LoadScene(1);

        StartCoroutine(SceneTransitionDelay());
        SceneManager.LoadScene(1);
    }

    public void Quit_Btn()
    {
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

    IEnumerator SceneTransitionDelay() 
    {
        yield return new WaitForSeconds(5);
    }
}
