using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockbackable, IDealDamage
{
    private bool isKnockbackActive;
    private float knockbackStartTime;

    public PlayerStat playerStat;
    public Resource resource;

    #region Hitbox
    public BoxCollider2D attack1;
    public BoxCollider2D attack2;
    #endregion

    public void LogicUpdate()
    {
        CheckKnockback();
    }

    public void Damage(float amount)
    {
        resource.currentHealth -= DamageCalculation(playerStat.currentDefense, amount);
    }

    public float DealDamage()
    {
        return playerStat.currentAttack;
    }

    public float DealStanceDamage()
    {
        return playerStat.stanceDamage;
    }

    public float DamageCalculation(float def, float atk)
    {
        return Mathf.Round(atk * (100 / (100 + def)));
    }

    public void Knockback(Vector2 angle, float strength, int direction)
    {
        core.Movement.SetVelocity(strength, angle, direction);
        core.Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if(isKnockbackActive && core.Movement.CurrentVelocity.y <= 0.01f && core.CollisionSenses.Ground)
        {
            isKnockbackActive = false;
            core.Movement.CanSetVelocity = true;
        }
    }
}
