using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPactLogic : MonoBehaviour
{
    [SerializeField] private LevelsInformation levelData;
    public bool IsPurified { get; private set; }
    
    //EVENTS 
    public delegate void PlayerInteractedWithPact();
    public static event PlayerInteractedWithPact OnPurifyPact;
    
    private void Start()
    {
        IsPurified = false;
    }

    public void Purify()
    {
        if (IsPurified) return;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; // to change later, change to some purify effect/new sprite
        IsPurified = true;
        levelData.PurifiedPacts++; // increments purified pacts to level manager
        OnPurifyPact?.Invoke(); // update ui
        
        //FUTURE WIN CONDITION
        if (levelData.IsLevelCompleted())
        {
            Debug.Log("PASSOU NIVEL!!");
        }
    }
}
