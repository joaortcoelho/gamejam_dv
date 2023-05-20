using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPactLogic : MonoBehaviour
{
    public bool IsPurified { get; private set; }
    [SerializeField] private LevelsInformation levelData;
    public delegate void PlayerInteractedWithPact();
    public static event PlayerInteractedWithPact OnPurifyPact;
    
    private void Start()
    {
        IsPurified = false;
    }

    public void Purify()
    {
        if (IsPurified) return;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        IsPurified = true;
        levelData.PurifiedPacts++;
        OnPurifyPact?.Invoke();
        if (levelData.IsLevelCompleted())
        {
            Debug.Log("PASSOU NIVEL!!");
        }
    }
}
