using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using Random = UnityEngine.Random;

public class EvilPactLogic : MonoBehaviour
{
    //REFS
    private GameObject aliveGO, brokenTopGO, brokenBotGO;
    private Rigidbody2D rbBrokenTop;
    private AudioSource audioSource;
    private Light2D light;
    private GameObject foundLight;
    [SerializeField] private ScriptableAudioClips deathSounds, rumbleSounds;
    [SerializeField] private LevelsInformation levelData;
    [SerializeField] private GameObject statueBrokenParticle;
    [SerializeField] private ParticleSystem crossParticles;
    public bool IsPurified { get; private set; }
    [SerializeField] private bool canRecover = false;

    //TIMER
    private float recoveryTimer = 0f;
    [SerializeField] private float recoveryCooldown = 5f;
    
    //EVENTS 
    public delegate void PlayerInteractedWithPact();
    public static event PlayerInteractedWithPact OnPurifyPact;
    
    private void Start()
    {
        // Initializing refs 
        aliveGO = transform.Find("Alive").gameObject;
        brokenBotGO = transform.Find("BrokenBot").gameObject;
        brokenTopGO = transform.Find("BrokenTop").gameObject;
        if (canRecover)
        {
            foundLight = transform.Find("FoundLight").gameObject;
            foundLight.SetActive(false);
        }
        rbBrokenTop = brokenTopGO.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        light = GetComponent<Light2D>();
        
        light.enabled = false;
        IsPurified = false;
        ChangeStatueActiveGo(true, false, false);

        PlaySound(rumbleSounds, 1.0f, false, .5f);
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
        PlaySound(deathSounds, .0f, true, 1f);
        //DESTROY STATUE
        DestroyStatue();
        crossParticles.Play();
        //FUTURE CHANGE LEVEL
        if (levelData.IsLevelCompleted())
        {
           Debug.Log("PROXIMO NIVEL MESSI");
        }
        
    }
    
    void PlaySound(ScriptableAudioClips sounds, float audio3DValue, bool doOneShot, float volume)
    {
        AudioClip clip = sounds.Clips[Random.Range(0, sounds.Clips.Length)];
        audioSource.spatialBlend = audio3DValue;
        audioSource.Stop();
        if (doOneShot)
        {
            audioSource.PlayOneShot(clip, volume);
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
        CameraShake.Instance.Shake(2f, .3f);
        ChangeStatueActiveGo(false, true, true);
        //tirar os magic numbers
        rbBrokenTop.AddForce((new Vector2(Random.Range(5f, 10f), Random.Range(5f, 10f))), ForceMode2D.Impulse);
        rbBrokenTop.AddTorque(2, ForceMode2D.Impulse);
        Instantiate(statueBrokenParticle, aliveGO.transform.position, statueBrokenParticle.transform.rotation);
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
            light.enabled = false;
            foundLight.SetActive(true);
            IsPurified = false;
            ChangeStatueActiveGo(true, false, false);
            brokenTopGO.transform.position = aliveGO.transform.position;
            levelData.PurifiedPacts--; // increments purified pacts to level manager
            OnPurifyPact?.Invoke(); // update ui
            audioSource.spatialBlend = 1.0f;
            PlaySound(rumbleSounds, 1.0f, false, .5f);
            crossParticles.Stop();
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
