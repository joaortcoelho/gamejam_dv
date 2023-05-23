using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandingParticleController : MonoBehaviour
{
    [SerializeField] private ParticleSystem dust;

    private void OnTriggerEnter2D(Collider2D other)
    {
        dust.Play();
    }
}
