using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private LevelsInformation levelData;
    void Awake()
    {
        levelData.OnAfterDeserialize();
        GameObject[] pactsObj = GameObject.FindGameObjectsWithTag("EvilPact");
        levelData.MaxPacts = pactsObj.Length;
    }
}
