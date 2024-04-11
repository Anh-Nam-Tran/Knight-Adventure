using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCombat : EntityCoreComponent, IDamageable, IKnockbackable, IDealDamage
{
    private bool isKnockbackActive;
    private float knockbackStartTime;

    public D_Entity entityStat;
    public EntityResource entityResource;

    #region Hitbox
    public BoxCollider2D attack;
    #endregion

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        entityResource.currentHealth -= DamageCalculation(entityStat.currentDefense, amount);
    }

    public void StanceDamage(float amount)
    {
        entityResource.currentStance -= amount;
    }

    public float DealDamage()
    {
        return entityStat.currentAttack;
    }

    public float DamageCalculation(float def, float atk)
    {
        return Mathf.Round(atk * (100 / (100 + def)));
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        entityCore.EntityMovement.SetVelocity(strength, angle, direction);
        entityCore.EntityMovement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if(isKnockbackActive && entityCore.EntityMovement.CurrentVelocity.y <= 0.01f && entityCore.EntityCollisionSenses.Ground)
        {
            isKnockbackActive = false;
            entityCore.EntityMovement.CanSetVelocity = true;
        }
    }
}
