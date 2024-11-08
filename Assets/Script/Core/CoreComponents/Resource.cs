using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : CoreComponent
{
    public ResourceBar healthBar;
    public ResourceBar staminaBar;
    public EntityStat stat;
    [field: SerializeField] public Stat Health { get; private set; }
    [field: SerializeField] public Stat Stamina { get; private set; }

    protected override void Awake()
    {
        base.Awake();

        Health.MaxValue = stat.maxHealth;
        Stamina.MaxValue = stat.maxStamina;

        healthBar.SetMaxValue(Health.MaxValue);
        staminaBar.SetMaxValue(Stamina.MaxValue);
            
        Health.Init();
        Stamina.Init();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        RegenStamina(stat.currentStaminaRegen);
        healthBar.SetValue(Health.CurrentValue);
        staminaBar.SetValue(Stamina.CurrentValue);
    }
    #region Stamina
    public void ConsumeStamina(float amount)
    {
        Stamina.Decrease(amount);
    }

    public void RegenStamina(float amount)
    {
        Stamina.Increase(amount);
    }

    public bool CheckCurrentStamina(float amount)
    {
        return Stamina.CurrentValue >= amount;
    }

    public bool CheckStaminaOutage()
    {
        return Stamina.CurrentValue <= 0;
    }
    public void FullyRestoreStamina()
    {
        Stamina.Init();
    }
    #endregion

    #region Health
    public void ConsumeHealth(float amount)
    {
        if (Health.CurrentValue > amount)
        {
            Health.Decrease(amount);
        }
    }

    public void RegenHealth(float amount)
    {
        Health.Increase(amount);
    }

    public void RestoreHealth(float amount)
    {
        Health.Increase(amount);
    }

    public bool CheckHealthOutage()
    {
        return Health.CurrentValue <= 0;
    }

    public void FullyRestoreHealth()
    {
        Health.Init();
    }
    #endregion
}
