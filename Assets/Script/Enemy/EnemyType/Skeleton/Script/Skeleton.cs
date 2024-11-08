using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Entity
{
    public SkeletonIdleState idleState { get; private set; }
    public SkeletonDamagedState damagedState { get; private set; }
    public SkeletonMoveState moveState { get; private set; }
    public SkeletonLookForPlayerState lookForPlayerState { get; private set; }
    public SkeletonPlayerDetectedState playerDetectedState { get; private set; }
    public SkeletonChargeState chargeState { get; private set; }
    public SkeletonMeleeAttackState meleeAttackState { get; private set; }
    public SkeletonDeadState deadState { get; private set; }
    [SerializeField] private D_IdleState idleStateData;
    [SerializeField] private D_DamagedState damagedStateData;
    [SerializeField] private D_MoveState moveStateData;
    [SerializeField] private D_LookForPlayer lookForPlayerData;
    [SerializeField] private D_PlayerDetected playerDetectedData;
    [SerializeField] private D_ChargeState chargeStateData;
    [SerializeField] private D_MeleeAttack meleeAttackData;
    [SerializeField] private D_DeadState deadStateData;

    [SerializeField]
    private Transform meleeAttackPosition;

    public override void Awake()
    {
        base.Awake();

        idleState = new SkeletonIdleState(this, stateMachine, "idle", idleStateData, this);
        damagedState = new SkeletonDamagedState(this, stateMachine, "damaged", damagedStateData, this);
        moveState = new SkeletonMoveState(this, stateMachine, "move", moveStateData, this);
        lookForPlayerState = new SkeletonLookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
        playerDetectedState = new SkeletonPlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new SkeletonChargeState(this, stateMachine, "charge", chargeStateData, this);
        meleeAttackState = new SkeletonMeleeAttackState(this, stateMachine, "attack", meleeAttackPosition, meleeAttackData, this);
        deadState = new SkeletonDeadState(this, stateMachine, "dead", deadStateData, this);
    }

    public override void Start()
    {
        stateMachine.Initialize(idleState);      
    }

    public override void Update()
    {
        base.Update();
    }

    private void DestroyOnDeath() => gameObject.SetActive(false);
}
