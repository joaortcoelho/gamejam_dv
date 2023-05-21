using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //DATA
    [SerializeField] public GameObject pointA;
    [SerializeField] public GameObject pointB;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform currentPoint;
    public float mSpeed;
    private Boolean facingRight;


    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        
    }
    
}
