using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInterction : MonoBehaviour
{
    private bool isInteracting;
    private float timer;
    [SerializeField]private float timeToPurify = 2f;

    private void Update()
    {
        CheckInteractInput();
    }

    void CheckInteractInput()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            isInteracting = true;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            isInteracting = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("EvilPact") || !isInteracting) return;
        EvilPactLogic pact = other.gameObject.GetComponent<EvilPactLogic>();
        if (pact == null) return;
        
        if (timer < timeToPurify && !pact.IsPurified) // cooldown while purifying
        {
            Debug.Log(timer);
            timer += Time.deltaTime;
        }
        else
        {
            pact.Purify();
            timer = 0;
        }
    }
}
