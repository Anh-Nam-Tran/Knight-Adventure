using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="newPlayerStat", menuName ="Data/Player Stat/Base Stat")]
public class PlayerStat : ScriptableObject
{
    [Header("Resource")]
    public float maxHealth = 500f;
    public float currentHealth = 500f;
    public float maxStamina = 100f;
    public float currentStamina = 100f;

    [Header("Attack")]
    public float baseAttack = 50f;
    public float currentAttack = 50f;
    public float baseCritChance = 0.1f;
    public float currentCritChance = 0.1f;
    public float baseCritDamage = 1.5f;
    public float currentCritDamage = 1.5f;

    [Header("Defense")]
    public float baseDefense = 25f;
    public float currentDefense = 25f;
    public float baseStance = 100f;
    public float currentStance = 100f;

    [Header("Stamina Consumption On Dodge")]
    public float baseStaminaConsumption = 25f;
    public float currentStaminaConsumption = 25f;
    public float baseStaminaRegen = 10f;
    public float currentStaminaRegen = 10f;

    [Header("Stamina Consumption On Attack")]
    public float baseAttackStamina = 20f;
    public float currentAttackStamina = 20f;

    [Header("Stance")]
    public float staminaDamage = 25f;
    public float stanceDamage = 50f;
}
