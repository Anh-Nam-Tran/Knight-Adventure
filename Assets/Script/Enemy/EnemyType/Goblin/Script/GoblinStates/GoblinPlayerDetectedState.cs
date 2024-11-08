using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinPlayerDetectedState : PlayerDetectedState
{
    private Goblin goblin;

    public GoblinPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
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

        if (goblin.isStaggered)
        {
            stateMachine.ChangeState(goblin.damagedState);
        }
        else if (goblin.isDead)
        {
            stateMachine.ChangeState(goblin.deadState);
        }
        else if (performCloseRangeAction)
        {
            stateMachine.ChangeState(goblin.meleeAttackState);
        }
        else if (performLongRangeAction)
        {            
            stateMachine.ChangeState(goblin.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(goblin.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
            Movement?.Flip();
            stateMachine.ChangeState(goblin.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
