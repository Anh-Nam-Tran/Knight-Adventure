using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    #region Components
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Animator anim { get; private set; }
    public EntityCore EntityCore { get; private set; }
    public int lastDamageDirection { get; private set; }
    #endregion

    #region Terrain Check
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private Transform ledgeCheck;
    [SerializeField] private Transform playerCheck;
    #endregion

    #region Status
    public bool isStaggered;
    public bool isStunned;
    public bool isDead;
    #endregion

    #region Resource
    private float currentHealth;
    private float currentStance;
    #endregion

    private Vector2 velocityWorkspace;

    public virtual void Awake()
    {
        EntityCore = GetComponentInChildren<EntityCore>();
        anim = GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
    } 

    public virtual void Start()
    {

    }

    public virtual void Update()
    {
        EntityCore.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
        isStaggered = EntityCore.EntityResource.CheckStanceOutage();

        anim.SetFloat("yVelocity", EntityCore.EntityMovement.RB.velocity.y);
    }

    public virtual void FixedUpdate()
    {
        stateMachine.currentState.PhysicsUpdate();
    }

    public virtual bool CheckPlayerInMinAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.minAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInMaxAgroRange()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.maxAgroDistance, entityData.whatIsPlayer);
    }

    public virtual bool CheckPlayerInCloseRangeAction()
    {
        return Physics2D.Raycast(playerCheck.position, transform.right, entityData.closeRangeActionDistance, entityData.whatIsPlayer);
    }

    private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

    private void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
