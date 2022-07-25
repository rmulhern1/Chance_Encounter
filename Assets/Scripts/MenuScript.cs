using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void Start_Btn()
    {
        SceneManager.LoadScene(1);
        Debug.Log("Quit Button pushed");
    }

    public void Quit_Btn()
    {
        Debug.Log("Quit Button pushed");
        Application.Quit();
    }

    public void About_Btn() 
    {
        Debug.Log("About button pushed");
        //Show panels for about section
    }

    public void Controls_Btn() 
    {
        Debug.Log("Controls button pushed");
        //Show panels for the how to section
    }
}
