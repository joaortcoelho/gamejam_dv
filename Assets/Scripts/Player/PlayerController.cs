using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // REFS
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask whatIsGround;
    private Rigidbody2D rb;

    private Animator animator;
    //BOOLS
    private bool isGrounded, jumpCommand, isFacingRight, isWalking;

    // PLAYER INPUT
    private float movementInput;
    
    //PLAYER MOVEMENT VALUES
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float deceleration = 2f;
    [SerializeField] private float velPower = 2f;
    [SerializeField] private float groundCheckRadius = 2f;
    
    //PLAYER JUMP VALUES
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        isFacingRight = true;
    }

    private void Update()
    {
        CheckInput();
        CheckIsGround();
        CheckMovementDirection();
        UpdateAnimations();
    }

    private void FixedUpdate()
    {
        Move();
        
        if (jumpCommand && isGrounded)
        {
            Jump();
            jumpCommand = false;
        }
        
        //VARIABLE JUMP HEIGHT && MORE GRAVITY WHEN JUMPING
        if (rb.velocity.y < 0)
        {
            rb.gravityScale = fallMultiplier;
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Z))
        {
            rb.gravityScale = lowJumpMultiplier;
        }
        else
        {
            rb.gravityScale = 1f;
        }
    
    }

    void Move()
    {
        float targetSpeed = movementInput * moveSpeed;
        
        float speedDif = targetSpeed - rb.velocity.x;
        
        float accelRate = (Math.Abs(targetSpeed) > 0.01f) ? acceleration : deceleration;

        float movement = Mathf.Pow(Mathf.Abs(speedDif) * accelRate, velPower) * Mathf.Sign(speedDif);
        
        rb.AddForce(movement * Vector2.right);
    }

    void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void CheckIsGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    
    private void CheckInput()
    {
        movementInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.GetKeyDown(KeyCode.Z))
        {
            jumpCommand = true;
        }
        
    }

    private void CheckMovementDirection()
    {
        if (isFacingRight && movementInput < 0)
        {
            Flip();
        }
        else if (!isFacingRight && movementInput > 0)
        {
            Flip();
        }

        isWalking = movementInput != 0;
    }
    
    private void Flip()
    {
        isFacingRight = !isFacingRight; 
        //transform.Rotate(0.0f, 180.0f, 0.0f);
        transform.localScale = new Vector2(-1, 1) * transform.localScale;
    }

    private void UpdateAnimations()
    {
        animator.SetBool("isWalking", isWalking);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("yVelocity", rb.velocity.y);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
