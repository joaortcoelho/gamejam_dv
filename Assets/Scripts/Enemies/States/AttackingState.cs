using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingState : State
{
    protected D_AttackingState stateData;
    
    
    public AttackingState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_AttackingState stateData) : base(entity, stateMachine, animBoolName)
    {
        this.stateData = stateData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
