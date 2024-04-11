using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonPlayerDetectedState : PlayerDetectedState
{
    private Skeleton skeleton;

    public SkeletonPlayerDetectedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_PlayerDetected stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
    {
        this.skeleton = skeleton;
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

        if (skeleton.isStaggered)
        {
            stateMachine.ChangeState(skeleton.damagedState);
        }
        else if (performCloseRangeAction)
        {
            stateMachine.ChangeState(skeleton.meleeAttackState);
        }
        else if (performLongRangeAction)
        {            
            stateMachine.ChangeState(skeleton.chargeState);
        }
        else if (!isPlayerInMaxAgroRange)
        {
            stateMachine.ChangeState(skeleton.lookForPlayerState);
        }
        else if (!isDetectingLedge)
        {
            entityCore.EntityMovement.Flip();
            stateMachine.ChangeState(skeleton.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
