using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resource : CoreComponent, IHealth, IStamina
{
    public ResourceBar healthBar;
    public ResourceBar staminaBar;
    public PlayerStat playerStat;
    public float currentHealth;
    public float currentStamina;

    public void LogicUpdate()
    {
        RegenStamina(playerStat.currentStaminaRegen);
        CheckStaminaCap();
        CheckHealthCap();
        healthBar.SetValue(currentHealth);
        staminaBar.SetValue(currentStamina);
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
        if (currentStamina >= playerStat.maxStamina)
        {
            currentStamina = playerStat.maxStamina;
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
        if (currentHealth >= playerStat.maxHealth)
        {
            currentHealth = playerStat.maxHealth;
        }

        else if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
    }
    #endregion
}
