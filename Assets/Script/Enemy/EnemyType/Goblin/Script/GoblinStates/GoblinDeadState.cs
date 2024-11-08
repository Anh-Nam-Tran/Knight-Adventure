using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDeadState : DeadState
{
    private Goblin goblin;

    public GoblinDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.goblin = goblin;
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
