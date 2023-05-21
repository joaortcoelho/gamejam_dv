using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    // REFS
    [SerializeField] private ScriptableFloat sanity;
    [SerializeField] private LevelsInformation levelData;
    
    //EVENTS
    public delegate void PlayerDamageCallback();
    public static event PlayerDamageCallback OnPlayerDamage;
    void Start()
    {
        sanity.OnAfterDeserialize();
    }
    void Update()
    {
        if (!levelData.IsLevelCompleted()) // do damage to player sanity && updates ui
        { 
            SanityMeter();
            OnPlayerDamage?.Invoke();
        }
    }

    void SanityMeter() // player sanity
    {
        if (sanity.Value > 0f)
        {
            //Debug.Log(sanity.Value);
            sanity.Value -= Time.deltaTime;
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("MORREU");
        Destroy(gameObject);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("EvilPact")) return;
        EvilPactLogic pact = other.gameObject.GetComponent<EvilPactLogic>();
        if (!pact.IsPurified || pact == null) return;

        sanity.OnAfterDeserialize(); // restore player sanity when close to purified pact.
    }
}
