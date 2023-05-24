using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject creditsMenuGO, tutorialMenuGO;

    private void Start()
    {
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
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
        creditsMenuGO.GetComponentInChildren<Button>().Select();
    }
    
    public void CloseCredits()
    {
        creditsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("playBtn"), new BaseEventData(EventSystem.current));
    }

    public void OpenTutorial()
    {
        tutorialMenuGO.SetActive(true);
        tutorialMenuGO.GetComponentInChildren<Button>().Select();
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(GameObject.Find("playBtn"), new BaseEventData(EventSystem.current));
    }
}
