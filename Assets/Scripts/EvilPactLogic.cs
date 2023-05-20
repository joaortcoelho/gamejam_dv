using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilPactLogic : MonoBehaviour
{
    public bool IsPurified { get; private set; }

    private void Start()
    {
        IsPurified = false;
    }

    public void Purify()
    {
        if (IsPurified) return;
        Debug.Log("Purifying...");
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        IsPurified = true;
    }
}
