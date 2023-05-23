using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f;
    public float destroyTimer = 3f;
    public Rigidbody2D rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * -projectileSpeed;

    }

    private void OnEnable()
    {
        Destroy(gameObject, destroyTimer);
    }

    public void SetVelocity(int direction)
    {
        rb.velocity = transform.right * (projectileSpeed * direction);
    }
}
