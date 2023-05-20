using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private ScriptableFloat sanity;
    [SerializeField] private LevelsInformation levelData;
    public delegate void PlayerDamageCallback();
    public static event PlayerDamageCallback OnPlayerDamage;
    void Start()
    {
        sanity.OnAfterDeserialize();
    }

    // Update is called once per frame
    void Update()
    {
        if (!levelData.IsLevelCompleted())
        { 
            SanityMeter();
            OnPlayerDamage?.Invoke();
        }
    }

    void SanityMeter()
    {
        if (sanity.Value > 0f)
        {
            //Debug.Log(sanity.Value);
            sanity.Value -= Time.deltaTime;
        }
        else
        {
            Debug.Log("MORREU");
            Destroy(gameObject);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.CompareTag("EvilPact")) return;
        EvilPactLogic pact = other.gameObject.GetComponent<EvilPactLogic>();
        if (!pact.IsPurified) return;

        sanity.OnAfterDeserialize();
    }
}
