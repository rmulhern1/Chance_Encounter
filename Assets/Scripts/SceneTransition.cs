using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] int levelToLoad;

    public bool loadLevel;

    private void Update()
    {
        //Waits for loadLevel boolean to change from animation event and then calls function
        if (loadLevel) {
            FadeToLevel(levelToLoad);
        }
    }

    /*public void FadeToNextLevel() 
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }*/

    public void FadeToLevel(int levelIndex) 
    {
        //Sets trigger in Animator to begin fade out
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void MenuFadeToLevel(int levelIndex)
    {
        //Sets Menu specific fade out of scene with custom animation
        levelToLoad = levelIndex;
        animator.SetTrigger("MenuFadeOut");
    }

    public void OnFadeComplete() 
    {
        //Loads the chosen scene after fade is complete
        SceneManager.LoadScene(levelToLoad);
    }
}
