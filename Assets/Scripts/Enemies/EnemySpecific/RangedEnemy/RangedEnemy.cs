using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Entity
{
    public RE_IdleState idleState { get; private set; }
    public RE_AttackingState attackingState { get; private set; }

    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_AttackingState attackingStateData;

    public override void Start()
    {
        base.Start();

        attackingState = new RE_AttackingState(this, stateMachine, "attacking", attackingStateData, this);
		idleState = new RE_IdleState(this, stateMachine, "idle", idleStateData, this);
        
        stateMachine.Initialize(idleState);
    }
}
