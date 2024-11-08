using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : CoreComponent, IDamageable, IKnockBackable, IDealDamage
{
    private Movement Movement { get => movement ?? core.GetCoreComponent(ref movement); }

	private Movement movement;

    private CollisionSenses CollisionSenses { get => collisionSenses ?? core.GetCoreComponent(ref collisionSenses); }

	private CollisionSenses collisionSenses;
    private bool isKnockbackActive;
    private float knockbackStartTime;
    public bool isDodging;

    public PlayerStat playerStat;
    public Resource resource;

    public void LogicUpdate()
    {
        CheckKnockback();
        Debug.Log(isDodging);
    }

    public void Damage(float amount)
    {
        if (!isDodging)
        {
            resource.Health.Decrease(DamageCalculation(playerStat.currentDefense, amount));
        }
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

    public void KnockBack(Vector2 angle, float strength, int direction)
    {
        Movement?.SetVelocity(strength, angle, direction);
        Movement.CanSetVelocity = false;
        isKnockbackActive = true;
        knockbackStartTime = Time.time;
    }

    private void CheckKnockback()
    {
        if(isKnockbackActive && Movement.CurrentVelocity.y <= 0.01f && CollisionSenses.Ground)
        {
            isKnockbackActive = false;
            Movement.CanSetVelocity = true;
        }
    }
}
