using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{
    public RE_IdleState idleState { get; private set; }
    public RE_MovingState movingState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_MovingState movingStateData;

    public override void Start()
    {
        base.Start();

        movingState = new RE_MovingState(this, stateMachine, "moving", movingStateData, this);
		idleState = new RE:IdleState(this, stateMachine, "idle", idleStateData, this);
    }
}
