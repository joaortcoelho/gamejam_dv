using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float destroyTimer = 3f;
    public Rigidbody2D rb;
    public float damage = 10f;
    [SerializeField] private ScriptableFloat sanity;
    private AudioSource audioSource;
    [SerializeField] private ScriptableAudioClips hitSounds;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -projectileSpeed;
        audioSource = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        Destroy(gameObject, destroyTimer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AudioClip clip = hitSounds.Clips[UnityEngine.Random.Range(0, hitSounds.Clips.Length)];
            audioSource.PlayOneShot(clip, 1f);
            sanity.Value -= damage;
            Debug.Log(sanity.Value);
        }
        Destroy(gameObject);
    }
}
