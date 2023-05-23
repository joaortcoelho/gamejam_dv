using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject creditsMenuGO, tutorialMenuGO;

    private void Start()
    {
        creditsMenuGO.SetActive(false);
        tutorialMenuGO.SetActive(false);
    }

    public void PlayLevelOne()
    {
        SceneManager.LoadScene("level1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettingsMenu()
    {
        
    }

    public void CloseSettingsMenu()
    {
        
    }

    public void OpenCredits()
    {
        creditsMenuGO.SetActive(true);
    }
    
    public void CloseCredits()
    {
        creditsMenuGO.SetActive(false);
    }

    public void OpenTutorial()
    {
        tutorialMenuGO.SetActive(true);
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
    }
}
