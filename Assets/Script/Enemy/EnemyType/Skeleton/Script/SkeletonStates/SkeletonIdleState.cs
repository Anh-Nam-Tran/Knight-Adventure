using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonIdleState : IdleState
{
    private Skeleton skeleton;

    public SkeletonIdleState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_IdleState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (skeleton.isDead)
        {
            stateMachine.ChangeState(skeleton.deadState);
        }
        else if (isIdleTimeOver)
        {
            stateMachine.ChangeState(skeleton.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
