using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

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
        
    }
    
    public void CloseOpenCredits()
    {
        
    }

    public void OpenTutorial()
    {
        
    }

    public void CloseTutorial()
    {
        
    }
}
