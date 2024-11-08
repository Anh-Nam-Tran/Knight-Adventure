using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Weapon : MonoBehaviour
{
    [SerializeField] private float attackCounterResetCooldown;
    public WeaponDataSO Data;
    public Player player;

    public int CurrentAttackCounter
    {
        get => currentAttackCounter;
        private set => currentAttackCounter = value >= Data.NumberOfAttacks ? 0 : value;
    }

    public event Action OnExit;
    public event Action OnEnter;

    private Animator anim;
    public GameObject BaseGameObject { get; private set; }
    public GameObject WeaponSpriteGameObject { get; private set; }
    public AnimationEventHandler EventHandler { get; private set; }
    public Core Core { get; private set; }
    private int currentAttackCounter;
    private Timer attackCounterResetTimer;

    public void Enter()
    {
        Debug.Log("Weapon enter!");

        attackCounterResetTimer.StopTimer();

        anim.SetBool("active", true);
        anim.SetInteger("counter", currentAttackCounter);

        OnEnter?.Invoke();
    }

    public void SetCore(Core core)
    {
        Core = core;
    }

    public void SetData(WeaponDataSO data)
    {
        Data = data;
    }

    private void Exit()
    {
        anim.SetBool("active", false);

        CurrentAttackCounter++;
        attackCounterResetTimer.StartTimer();

        OnExit?.Invoke();
    }

    private void Awake()
    {
        player = transform.parent.gameObject.GetComponent<Player>();
        BaseGameObject = transform.Find("Base").gameObject;
        WeaponSpriteGameObject = transform.Find("WeaponSprite").gameObject;
        anim = BaseGameObject.GetComponent<Animator>();
        EventHandler = BaseGameObject.GetComponent<AnimationEventHandler>();

        attackCounterResetTimer = new Timer(attackCounterResetCooldown);
    }

    private void Update()
    {
        attackCounterResetTimer.Tick();
    }

    private void ResetAttackCounter() => CurrentAttackCounter = 0;

    private void OnEnable()
    {
        EventHandler.OnFinish += Exit;
        attackCounterResetTimer.OnTimerDone += ResetAttackCounter;
    }

    private void OnDisable()
    {
        EventHandler.OnFinish -= Exit;
        attackCounterResetTimer.OnTimerDone -= ResetAttackCounter;
    }

}
