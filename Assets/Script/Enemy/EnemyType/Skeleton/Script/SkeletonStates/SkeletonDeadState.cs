using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDeadState : DeadState
{
    private Skeleton skeleton;

    public SkeletonDeadState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DeadState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
