using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EvilPactLogic : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private ScriptableAudioClips sounds;
    [SerializeField] private LevelsInformation levelData;
    private Light2D light; 
    public bool IsPurified { get; private set; }
    [SerializeField] private bool canRecover = false;
    
    //EVENTS 
    public delegate void PlayerInteractedWithPact();
    public static event PlayerInteractedWithPact OnPurifyPact;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        light = GetComponent<Light2D>();
        light.enabled = false;
        IsPurified = false;
    }

    public void Purify()
    {
        if (IsPurified) return;
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow; // to change later, change to some purify effect/new sprite
        IsPurified = true;
        light.enabled = true;
        levelData.PurifiedPacts++; // increments purified pacts to level manager
        OnPurifyPact?.Invoke(); // update ui
        PlayDeathSound();
        //FUTURE WIN CONDITION
        if (levelData.IsLevelCompleted())
        {
            Debug.Log("PASSOU NIVEL!!");
        }
    }

    void PlayDeathSound()
    {
        audioSource.Stop();
        AudioClip clip = sounds.Clips[UnityEngine.Random.Range(0, sounds.Clips.Length)];
        audioSource.PlayOneShot(clip);
    }
}
