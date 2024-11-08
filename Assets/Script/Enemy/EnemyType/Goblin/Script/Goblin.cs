using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblin : Entity
{
    public GoblinIdleState idleState { get; private set; }
    public GoblinDamagedState damagedState { get; private set; }
    public GoblinMoveState moveState { get; private set; }
    public GoblinLookForPlayerState lookForPlayerState { get; private set; }
    public GoblinPlayerDetectedState playerDetectedState { get; private set; }
    public GoblinChargeState chargeState { get; private set; }
    public GoblinMeleeAttackState meleeAttackState { get; private set; }
    public GoblinDeadState deadState { get; private set; }
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

        idleState = new GoblinIdleState(this, stateMachine, "idle", idleStateData, this);
        damagedState = new GoblinDamagedState(this, stateMachine, "damaged", damagedStateData, this);
        moveState = new GoblinMoveState(this, stateMachine, "move", moveStateData, this);
        lookForPlayerState = new GoblinLookForPlayerState(this, stateMachine, "lookForPlayer", lookForPlayerData, this);
        playerDetectedState = new GoblinPlayerDetectedState(this, stateMachine, "playerDetected", playerDetectedData, this);
        chargeState = new GoblinChargeState(this, stateMachine, "charge", chargeStateData, this);
        meleeAttackState = new GoblinMeleeAttackState(this, stateMachine, "attack", meleeAttackPosition, meleeAttackData, this);
        deadState = new GoblinDeadState(this, stateMachine, "dead", deadStateData, this);
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
