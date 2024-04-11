using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackState : PlayerAbilityState
{
    private int xInput;
    private float velocityToSet;
    private bool setVelocity;
    public PlayerAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();
        setVelocity = false;
        player.InputHandler.UseAttackInput();
        if (player.attackCounter >= 2)
        {
            player.AttackCounterReset();
        }
        else
        {
            player.AttackCounterIncrease();
        }
        player.Anim.SetInteger("attack", player.attackCounter);
        player.attackStartTime = Time.time;
        core.Movement.SetVelocityX(playerData.attackVelocity * core.Movement.FacingDirection);
        core.Resource.ConsumeStamina(core.Resource.playerStat.currentAttackStamina);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (isAnimationFinished)
            {
                isAbilityDone = true;
            }
        }
    }
}
