using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinLookForPlayerState : LookForPlayerState
{
    private Goblin goblin;

    public GoblinLookForPlayerState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_LookForPlayer stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
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
        else if (isPlayerInMinAgroRange)
        {
            stateMachine.ChangeState(goblin.playerDetectedState);
        }
        else if (isAllTurnsTimeDone)
        {
            stateMachine.ChangeState(goblin.moveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
