using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMoveState : MoveState
{
    private Goblin goblin;

    public GoblinMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(goblin.playerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            goblin.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(goblin.idleState);
        }
        else if (goblin.isStaggered)
        {
            stateMachine.ChangeState(goblin.damagedState);
        }
        else if (goblin.isDead)
        {
            stateMachine.ChangeState(goblin.deadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
