using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;
using Cursor = UnityEngine.Cursor;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private GameObject creditsMenuGO, tutorialMenuGO;
    [SerializeField] private GameObject character;
    [SerializeField] private GameObject playBtn;

    private void Start()
    {
        Cursor.visible = false;
        if (creditsMenuGO && tutorialMenuGO)
        {
            creditsMenuGO.SetActive(false);
            tutorialMenuGO.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetAxis("Cancel") == 1f)
        {
            CloseCredits();
            CloseTutorial();
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
        character.SetActive(false);
    }
    
    public void CloseCredits()
    {
        creditsMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
        character.SetActive(true);
    }

    public void OpenTutorial()
    {
        tutorialMenuGO.SetActive(true);
        tutorialMenuGO.GetComponentInChildren<Button>().Select();
        character.SetActive(false);
    }

    public void CloseTutorial()
    {
        tutorialMenuGO.SetActive(false);
        EventSystem.current.SetSelectedGameObject(playBtn, new BaseEventData(EventSystem.current));
        character.SetActive(true);
    }
}
