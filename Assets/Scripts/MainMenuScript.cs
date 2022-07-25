using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
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
}
