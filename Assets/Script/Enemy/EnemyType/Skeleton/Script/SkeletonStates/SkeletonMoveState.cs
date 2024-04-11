using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMoveState : MoveState
{
    private Skeleton skeleton;

    public SkeletonMoveState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MoveState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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

        if (isPlayerInMinAggroRange)
        {
            stateMachine.ChangeState(skeleton.playerDetectedState);
        }
        else if (isDetectingWall || !isDetectingLedge)
        {
            skeleton.idleState.SetFlipAfterIdle(true);
            stateMachine.ChangeState(skeleton.idleState);
        }
        else if (skeleton.isStaggered)
        {
            stateMachine.ChangeState(skeleton.damagedState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
