using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonDamagedState : DamagedState
{
    private Skeleton skeleton;

    public SkeletonDamagedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DamagedState stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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
        entity.resource.FullyRestoreStamina();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(skeleton.meleeAttackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(skeleton.lookForPlayerState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(skeleton.chargeState);
            }
        }
        if (skeleton.isDead)
        {
            stateMachine.ChangeState(skeleton.deadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
