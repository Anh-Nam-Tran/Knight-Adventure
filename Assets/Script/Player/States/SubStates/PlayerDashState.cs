using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerAbilityState
{
    public bool CanDash { get; private set; } = true;
    private bool isHolding;
    private bool dashInputStop;

    private float lastDashTime;

    private Vector2 dashDirection;
    private Vector2 dashDirectionInput;
    private Vector2 lastAIPos;

    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {

    }
    public override void Enter()
    {
        base.Enter();

        CanDash = false;
        //Combat.isDodging = true;
        player.InputHandler.UseDashInput();
        dashDirection = Vector2.right * Movement.FacingDirection;
        Movement?.SetVelocity(playerData.dashVelocity, dashDirection);
        Resource?.ConsumeStamina(Resource.stat.currentStaminaConsumption);
    }

    public override void Exit()
    {
        base.Exit();

        if(Movement.CurrentVelocity.y > 0)
        {
            Movement?.SetVelocityY(Movement.CurrentVelocity.y * playerData.dashEndYMultiplier);
        }
        ResetCanDash();
        //Combat.isDodging = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        if (!isExitingState)
        {
            if (!isAnimationFinished)
            {
                player.InputHandler.UseDashInput();
            }
        }

        if (!isExitingState)
        {
            if (isAnimationFinished)
            {
                isAbilityDone = true;
            }
        }
    }

    private void CheckIfShouldPlaceAfterImage()
    {
        /*if(Vector2.Distance(player.transform.position, lastAIPos) >= playerData.distBetweenAfterImages)
        {
            PlaceAfterImage();
        }*/
    }

    /*private void PlaceAfterImage()
    {
        PlayerAfterImagePool.Instance.GetFromPool();
        lastAIPos = player.transform.position;
    }*/

    public bool CheckIfCanDash()
    {
        return CanDash && Time.time >= lastDashTime + playerData.dashCooldown;
    }

    public void ResetCanDash() => CanDash = true;

}
