using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblinDamagedState : DamagedState
{
    private Goblin goblin;

    public GoblinDamagedState(Entity entity, FiniteStateMachine stateMachine, string animBoolName, D_DamagedState stateData, Goblin goblin) : base(entity, stateMachine, animBoolName, stateData)
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
        entity.resource.FullyRestoreStamina();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (isAnimationFinished)
        {
            if (performCloseRangeAction)
            {
                stateMachine.ChangeState(goblin.meleeAttackState);
            }
            else if (!isPlayerInMaxAgroRange)
            {
                stateMachine.ChangeState(goblin.lookForPlayerState);
            }
            else if (isPlayerInMinAgroRange)
            {
                stateMachine.ChangeState(goblin.chargeState);
            }
        }
        if (goblin.isDead)
        {
            stateMachine.ChangeState(goblin.deadState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
