using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RangedEnemy : MonoBehaviour
{
    /*private Rigidbody2D rb;
    
    [SerializeField] private float jumpPower = 10.0f;
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float attackPower = 20.0f;*/

    private enum State
    {
        Moving,
        Attacking,
        Dead
    }

    [SerializeField] private float groundCheckDistance, wallCheckDistance, mSpeed;
    [SerializeField] private Transform groundCheck, wallCheck;
    [SerializeField] private LayerMask whatIsGround;
    
    private State currentState;
    private bool groundDetected, wallDetected;
    private int facingDirection;
    private GameObject alive;
    private Rigidbody2D aliveRB;
    private Animator anim;
    private Vector2 movement;

    private void Start()
    {
        alive = transform.Find("Alive").GameObject();
        aliveRB = alive.GetComponent<Rigidbody2D>();
        anim = alive.GetComponent<Animator>();
        facingDirection = -1;
    }

    private void Update()
    {
        switch (currentState)
        {
            case State.Moving:
                UpdateMovingState();
                break;
            case State.Attacking:
                UpdateAttackingState();
                break;
            case State.Dead:
                UpdateDeadState();
                break;
        }
    }
    
    //MOVING STATE------------------------------------------------------------------------
    private void EnterMovingState()
    {
        
    }
    
    private void UpdateMovingState()
    {
        groundDetected = Physics2D.Raycast(groundCheck.position, Vector2.down, groundCheckDistance, whatIsGround);
        wallDetected = Physics2D.Raycast(wallCheck.position, transform.right, wallCheckDistance, whatIsGround);

        if (!groundDetected || wallDetected)
        {
            Flip();
        }
        else
        {
            //Move
            movement.Set(mSpeed * facingDirection, aliveRB.velocity.y);
            aliveRB.velocity = movement;
        }
    }
    
    private void ExitMovingState()
    {
        
    }
    
    //ATTACKING STATE----------------------------------------------------------------------
    private void EnterAttackingState()
    {
        
    }
    
    private void UpdateAttackingState()
    {
        
    }
    
    private void ExitAttackingState()
    {
        
    }
    
    //DEAD STATE--------------------------------------------------------------------------
    private void EnterDeadState()
    {
        Destroy(gameObject);
    }
    
    private void UpdateDeadState()
    {
        
    }
    
    private void ExitDeadState()
    {
        
    }
    
    //OTHER FUNCTIONS--------------------------------------------------------------------
    private void SwitchState(State state)
    {
        switch (currentState)
        {
            case State.Moving:
                ExitMovingState();
                break;
            case State.Attacking:
                ExitAttackingState();
                break;
            case State.Dead:
                ExitDeadState();
                break;
        }
        
        switch (state)
        {
            case State.Moving:
                EnterMovingState();
                break;
            case State.Attacking:
                EnterAttackingState();
                break;
            case State.Dead:
                EnterDeadState();
                break;
        }

        currentState = state;
    }

    private void Flip()
    {
        facingDirection *= -1;
        alive.transform.Rotate(0.0f, 180.0f, 0.0f);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position, new Vector2(groundCheck.position.x, groundCheck.position.y - groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position, new Vector2(wallCheck.position.x + wallCheckDistance, wallCheck.position.y));
    }
}
