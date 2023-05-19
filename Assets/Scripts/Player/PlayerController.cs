using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    // REFS
    [SerializeField] private Transform groundCheck;
    private Rigidbody2D rb;
    
    //BOOLS
    private bool isGrounded, jumpCommand, isInteracting;

    // OTHER VALUES
    private float movementInput;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private float groundCheckRadius = 2f;
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float acceleration = 2f;
    [SerializeField] private float decceleration = 2f;
    [SerializeField] private float velPower = 2f;
    
    //JUMP VALUES
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        CheckInput();
        CheckIsGround();


    }

    private void FixedUpdate()
    {
        Move();
        
        if (jumpCommand && isGrounded)
        {
            Jump();
            jumpCommand = false;
        }

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
        
        float accelRate = (Math.Abs(targetSpeed) > 0.01f) ? acceleration : decceleration;

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

        if (Input.GetKeyDown(KeyCode.X))
        {
            isInteracting = true;
        }

        if (Input.GetKeyUp(KeyCode.X))
        {
            isInteracting = false;
        }


    }

    
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }

    private bool CountDownTimer()
    {
        int countDownStartValue = 5;
        if (countDownStartValue > 0)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(countDownStartValue);
            Debug.Log(countDownStartValue);
            countDownStartValue--;
            Invoke("CountDownTimer", 1.0f);
        }
        else
        {
            return true;
        }
        
        return false;
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (other.CompareTag("EvilPact") && isInteracting)
        {
            
            if (CountDownTimer())
            {
                Debug.Log("MESSI");
                other.gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
