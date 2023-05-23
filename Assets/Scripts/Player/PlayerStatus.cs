using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    // REFS
    [SerializeField] private ScriptableFloat sanity;
    [SerializeField] private LevelsInformation levelData;

    [SerializeField] private GameObject deathChunkParticle, deathBloodParticle;
    //EVENTS
    public delegate void PlayerDamageCallback();
    public static event PlayerDamageCallback OnPlayerDamage;
    public static event PlayerDamageCallback OnPlayerDeath;
    void Start()
    {
        Time.timeScale = 1f;
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
        else if (sanity.Value <= 0f)
        {
        
            Die();

        }
    }

    private void Die()
    {
        CameraShake.Instance.Shake(2f, .2f);
        Instantiate(deathChunkParticle, transform.position, deathChunkParticle.transform.rotation);
        Instantiate(deathBloodParticle, transform.position, deathBloodParticle.transform.rotation);
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
