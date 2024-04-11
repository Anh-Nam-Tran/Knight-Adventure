using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : ScriptableObject
{
    [Header("Resource")]
    public float maxHealth = 500f;
    public float currentHealth = 500f;
    public float maxStamina = 100f;
    public float currentStamina = 100f;
    public float baseStaminaRegen = 10f;
    public float currentStaminaRegen = 10f;

    [Header("Attack")]
    public float baseAttack = 250f;
    public float currentAttack = 250f;
    public float baseCritChance = 0.1f;
    public float currentCritChance = 0.1f;
    public float baseCritDamage = 1.5f;
    public float currentCritDamage = 1.5f;

    [Header("Defense")]
    public float baseDefense = 25f;
    public float currentDefense = 25f;

    //public float damageHopSpeed = 3f;

    [Header("Terrain Check")]
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;

    [Header("Aggro")]
    public float minAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    [Header("Stance")]
    public float baseStance = 100f;
    public float currentStance = 100f;
    public float stunRecoveryTime = 2f;

    [Header("Action Distance")]
    public float closeRangeActionDistance = 1f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
