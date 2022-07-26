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
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void OnFadeComplete() 
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
