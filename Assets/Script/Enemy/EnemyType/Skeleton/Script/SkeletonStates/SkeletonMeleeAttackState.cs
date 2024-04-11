using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMeleeAttackState : MeleeAttackState
{
    private Skeleton skeleton;

    public SkeletonMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_MeleeAttack stateData, Skeleton skeleton) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isAnimationFinished)
        {
            if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(skeleton.playerDetectedState);
            }
            else
            {
                stateMachine.ChangeState(skeleton.lookForPlayerState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
