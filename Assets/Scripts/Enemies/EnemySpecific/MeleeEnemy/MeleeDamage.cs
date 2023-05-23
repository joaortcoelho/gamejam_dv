using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour
{
    [SerializeField] private ScriptableFloat sanity;
    public float damage = 5f;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            sanity.Value -= damage;
            Debug.Log(sanity.Value);
        }
    }
}
