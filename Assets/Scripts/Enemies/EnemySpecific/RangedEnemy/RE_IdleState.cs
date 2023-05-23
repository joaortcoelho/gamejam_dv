using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RE_IdleState : IdleState
{
    private RangedEnemy enemy;
    
    public RE_IdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, RangedEnemy enemy) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Entering Idle");
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isIdleTimeOver)
        {
            stateMachine.ChangeState(enemy.attackingState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
