using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    private Movement Movement { get => movement ?? Core.GetCoreComponent(ref movement); }

	private Movement movement;
    #region Components
    public FiniteStateMachine stateMachine;
    public D_Entity entityData;
    public Animator anim { get; private set; }
    public AnimationToStatemachine atsm;
    public Core Core { get; private set; }
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
    public Resource resource;
    #endregion

    private Vector2 velocityWorkspace;

    public virtual void Awake()
    {
        Core = GetComponentInChildren<Core>();

        resource = Core.GetCoreComponent<Resource>();
        anim = GetComponent<Animator>();
        stateMachine = new FiniteStateMachine();
        atsm = GetComponent<AnimationToStatemachine>();
    } 

    public virtual void Start()
    {
        Debug.Log(Movement);
    }

    public virtual void Update()
    {
        Core.LogicUpdate();
        stateMachine.currentState.LogicUpdate();
        isStaggered = resource.CheckStaminaOutage();
        isDead = resource.CheckHealthOutage();

        anim.SetFloat("yVelocity", Movement.RB.velocity.y);
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

    public virtual void DamageHop(float velocity) {
		velocityWorkspace.Set(Movement.RB.velocity.x, velocity);
		Movement.RB.velocity = velocityWorkspace;
	}

    private void AnimationTrigger() => stateMachine.currentState.AnimationTrigger();

    private void AnimationFinishTrigger() => stateMachine.currentState.AnimationFinishTrigger();
}
