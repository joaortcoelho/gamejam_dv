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
    void Awake()
    {
        levelData.OnAfterDeserialize();
        GameObject[] pactsObj = GameObject.FindGameObjectsWithTag("EvilPact");
        levelData.MaxPacts = pactsObj.Length;
        transitionTimer = 0;
        GetComponent<AudioListener>().enabled = false;
        
    }

    private void Start()
    {
        grayscale.profile.TryGet(out ca);
    }

    private void Update()
    {
        if (playerSanity.Value <= 10f)
        {
            ca.saturation.value = -84f;
        }else if (playerSanity.Value > 10f)
        {
            ca.saturation.value = 0;
        }
        
        if (levelData.IsLevelCompleted())
        {
            //teste, aqui é suposto levar para o proximo nivel
            if (transitionTimer < 3f)
            {
                transitionTimer += Time.deltaTime;
                
            }else if (transitionTimer >= 2f)
            {
                SceneManager.LoadScene("WinScreen");
                transitionTimer = 0;
            }
            
        }
        if (playerSanity.Value <= 0f)
        {
            GetComponent<AudioListener>().enabled = true;
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
}
