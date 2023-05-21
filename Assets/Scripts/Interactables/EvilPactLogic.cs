using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class EvilPactLogic : MonoBehaviour
{
    //REFS
    private GameObject aliveGO, brokenTopGO, brokenBotGO;
    private Rigidbody2D rbBrokenTop;
    private AudioSource audioSource;
    [SerializeField] private ScriptableAudioClips deathSounds, rumbleSounds, heartSounds;
    [SerializeField] private LevelsInformation levelData;
    private Light2D light; 
    
    public bool IsPurified { get; private set; }
    [SerializeField] private bool canRecover = false;

    private float recoveryTimer = 0f;
    [SerializeField] private float recoveryCooldown = 5f;
    //EVENTS 
    public delegate void PlayerInteractedWithPact();
    public static event PlayerInteractedWithPact OnPurifyPact;
    private void Start()
    {
        aliveGO = transform.Find("Alive").gameObject;
        brokenBotGO = transform.Find("BrokenBot").gameObject;
        brokenTopGO = transform.Find("BrokenTop").gameObject;
        rbBrokenTop = brokenTopGO.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        light = GetComponent<Light2D>();
        
        light.enabled = false;
        IsPurified = false;
        ChangeStatueActiveGo(true, false, false);

        PlaySound(rumbleSounds, 1.0f, false);
    }

    private void Update()
    {
        if (canRecover && IsPurified && !levelData.IsLevelCompleted())
        {
            StartRecovery();
        }
    }

    public void Purify()
    {
        if (IsPurified) return;
        IsPurified = true;
        light.enabled = true;
        levelData.PurifiedPacts++; // increments purified pacts to level manager
        OnPurifyPact?.Invoke(); // update level ui
        PlaySound(deathSounds, 0.0f, true);
        //DESTROY STATUE
        DestroyStatue();

        //FUTURE CHANGE LEVEL
        if (levelData.IsLevelCompleted())
        {
           Debug.Log("PROXIMO NIVEL MESSI");
        }
        
    }
    
    void PlaySound(ScriptableAudioClips sounds, float audio3DValue, bool doOneShot)
    {
        AudioClip clip = sounds.Clips[UnityEngine.Random.Range(0, sounds.Clips.Length)];
        audioSource.spatialBlend = audio3DValue;
        audioSource.Stop();
        if (doOneShot)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            audioSource.clip = clip;
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    void DestroyStatue()
    {
        ChangeStatueActiveGo(false, true, true);
        //tirar os magic numbers
        rbBrokenTop.AddForce(new Vector2(6, 3), ForceMode2D.Impulse);
        rbBrokenTop.AddTorque(1, ForceMode2D.Impulse);
    }

    void StartRecovery()
    {
        //PlaySound(heartSounds, 1.0f, false);
        if (recoveryTimer < recoveryCooldown)
        {
            recoveryTimer += Time.deltaTime;
            Debug.Log("Turning evil... " + recoveryTimer);
        }
        else
        {
            IsPurified = false;
            ChangeStatueActiveGo(true, false, false);
            brokenTopGO.transform.position = aliveGO.transform.position;
            levelData.PurifiedPacts--; // increments purified pacts to level manager
            OnPurifyPact?.Invoke(); // update ui
            audioSource.spatialBlend = 1.0f;
            PlaySound(rumbleSounds, 1.0f, false);
            recoveryTimer = 0f;
        }
    }

    private void ChangeStatueActiveGo(bool aliveState, bool brokenTopState, bool brokenBotState)
    {
        aliveGO.SetActive(aliveState);
        brokenTopGO.SetActive(brokenTopState);
        brokenBotGO.SetActive(brokenBotState);
    }
}
