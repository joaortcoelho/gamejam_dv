using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelsInformation levelData;
    [SerializeField] private ScriptableFloat playerSanity;
    [SerializeField] private Volume grayscale;
    private ColorAdjustments ca;
    private float transitionTimer;
    private AudioSource audioSource;
    [SerializeField] private AudioClip deathSound;
    void Awake()
    {
        levelData.OnAfterDeserialize();
        GameObject[] pactsObj = GameObject.FindGameObjectsWithTag("EvilPact");
        levelData.MaxPacts = pactsObj.Length;
        transitionTimer = 0;
        gameObject.GetComponent<AudioListener>().enabled = false;        
    }

    private void OnEnable()
    {
        PlayerStatus.OnPlayerDeath += PlayDeathSound;
    }

    private void OnDisable()
    {
        PlayerStatus.OnPlayerDeath -= PlayDeathSound;
    }

    private void Start()
    {
        grayscale.profile.TryGet(out ca);
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        PlayerLowHealthEffect();
        CurrLevelDoneDoNextLevel();
        PlayerDeadScreen();

    }
    public void PlayDeathSound()
    {
        gameObject.GetComponent<AudioListener>().enabled = true;        
        audioSource.PlayOneShot(deathSound, 1f);
    }

    private void PlayerLowHealthEffect()
    {
        if (playerSanity.Value <= 10f)
        {
            ca.saturation.value = -84f;
        }else if (playerSanity.Value > 10f)
        {
            ca.saturation.value = 0;
        }
    }
    
    private void PlayerDeadScreen()
    {
        if (playerSanity.Value <= 0f)
        {

            if (transitionTimer < 3f)
            {
                transitionTimer += Time.deltaTime;
                
            }else if (transitionTimer >= 3f)
            {
                SceneManager.LoadScene("DeathScreen");
                transitionTimer = 0;
            }
        }
    }
    
    private void CurrLevelDoneDoNextLevel()
    {
        if (levelData.IsLevelCompleted())
        {
            if (transitionTimer < 3f)
            {
                transitionTimer += Time.deltaTime;
                
            }else if (transitionTimer >= 2f)
            {
                transitionTimer = 0;
                SceneManager.LoadScene(levelData.NextLevel);
            }
            
        }
    }
}
