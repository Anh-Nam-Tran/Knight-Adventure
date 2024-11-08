using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinChargeState : ChargeState
{
    private Goblin goblin;

    public GoblinChargeState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_ChargeState stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (!isDetectingLedge || isDetectingWall)
        {
            stateMachine.ChangeState(goblin.lookForPlayerState);
        }
        else if (isChargeTimeOver)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(goblin.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(goblin.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
