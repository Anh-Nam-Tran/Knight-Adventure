using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponMovement : WeaponComponent<WeaponMovementData, AttackMovement>
{
    private Movement coreMovement;
    private Movement CoreMovement =>
            coreMovement ? coreMovement : Core.GetCoreComponent(ref coreMovement);

    private void HandleStartMovement()
    {
        CoreMovement.SetVelocity(currentAttackData.Velocity, currentAttackData.Direction, CoreMovement.FacingDirection);
    }

    private void HandleStopMovement()
    {
        CoreMovement.SetVelocityZero();
    }

    protected override void Start()
    {
        base.Start();

        eventHandler.OnStartMovement += HandleStartMovement;
        eventHandler.OnStopMovement += HandleStopMovement;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        eventHandler.OnStartMovement -= HandleStartMovement;
        eventHandler.OnStopMovement -= HandleStopMovement;
    }
}