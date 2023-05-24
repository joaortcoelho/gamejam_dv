using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuLogic : MonoBehaviour
{
    [SerializeField] GameObject pauseMenuScreen;
    private void OnEnable()
    {
        PlayerController.OnPausePressed += PauseGame;
    }

    private void OnDisable()
    {
        PlayerController.OnPausePressed -= PauseGame;
    }
    private void Awake()
    {

        Time.timeScale = 1f;
    }

    public void ContinueGame()
    {
        AudioSource[] audios = FindObjectsOfType<AudioSource>();
        pauseMenuScreen.SetActive(false);
        Time.timeScale = 1f;
        foreach (AudioSource audio in audios)
        {
            audio.Play();
        }
    }

    private void PauseGame()
    {
        if (!pauseMenuScreen.activeSelf)
        {
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            pauseMenuScreen.SetActive(true);
            Time.timeScale = 0f;
            foreach (AudioSource audio in audios)
            {
                audio.Pause();
            }
        }
        else if (pauseMenuScreen.activeSelf)
        {
            ContinueGame();
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
