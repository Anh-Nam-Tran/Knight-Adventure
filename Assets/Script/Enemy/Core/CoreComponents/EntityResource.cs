using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityResource : EntityCoreComponent, IHealth, IStamina
{
    public EnemyResourceBar healthBar;
    public EnemyResourceBar stanceBar;
    public D_Entity entityStat;
    public float currentHealth;
    public float currentStamina;
    public float currentStance;

    public void LogicUpdate()
    {
        RegenStamina(entityStat.currentStaminaRegen);
        CheckStaminaCap();
        CheckHealthCap();
        CheckStanceCap();
        healthBar.ChangeXScale(currentHealth, entityStat.maxHealth);
        stanceBar.ChangeXScale(currentStance, entityStat.baseStance);
    }
    #region Stamina
    public void ConsumeStamina(float amount)
    {
        currentStamina -= amount;
    }

    public void RegenStamina(float amount)
    {
        currentStamina += amount;
    }

    public void CheckStaminaCap()
    {
        if (currentStamina >= entityStat.maxStamina)
        {
            currentStamina = entityStat.maxStamina;
        }

        else if (currentStamina <= 0)
        {
            currentStamina = 0;
        }
    }

    public bool CheckCurrentStamina(float amount)
    {
        return currentStamina >= amount;
    }

    public bool CheckStaminaOutage()
    {
        return currentStamina <= 0;
    }
    #endregion

    #region Health
    public void ConsumeHealth(float amount)
    {
        if (currentHealth > amount)
        {
            currentHealth -= amount;
        }
    }

    public void RegenHealth(float amount)
    {
        currentHealth += amount;
    }

    public void RestoreHealth(float amount)
    {
        currentHealth += amount;
    }

    public void CheckHealthCap()
    {
        if (currentHealth >= entityStat.maxHealth)
        {
            currentHealth = entityStat.maxHealth;
        }

        else if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }

    public bool CheckHealthOutage()
    {
        return currentHealth <= 0;
    }
    #endregion

    #region Stance
    public void CheckStanceCap()
    {
        if (currentStance >= entityStat.baseStance)
        {
            currentStance = entityStat.baseStance;
        }

        else if (currentStance <= 0)
        {
            currentStance = 0;
        }
    }

    public void RestoreStance()
    {
        currentStance = entityStat.baseStance;
    }

    public bool CheckStanceOutage()
    {
        return currentStance <= 0;
    }
    #endregion
}
