using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField] private ScriptableAudioClips hitSounds;
    
    [SerializeField] private ScriptableFloat sanity;
    public float damage = 5f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            AudioClip clip = hitSounds.Clips[UnityEngine.Random.Range(0, hitSounds.Clips.Length)];
            audioSource.PlayOneShot(clip, 1f);
            sanity.Value -= damage;
            Debug.Log(sanity.Value);
        }
    }
}
