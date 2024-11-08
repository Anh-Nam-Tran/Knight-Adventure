using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinMeleeAttackState : MeleeAttackState
{
    private Goblin goblin;

    public GoblinMeleeAttackState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, Transform attackPosition, D_MeleeAttack stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, attackPosition, stateData)
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
        else if (isAnimationFinished)
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
