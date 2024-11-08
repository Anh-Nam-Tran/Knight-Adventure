using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class Damage : WeaponComponent<DamageData, AttackDamage>
{
    private ActionHitbox hitBox;
    private Weapon weapon;

    private void HandleDetectCollider2D(Collider2D[] colliders)
    {
        foreach (var item in colliders)
        {
            if (item.TryGetComponent(out IDamageable damageable))
            {
                damageable.Damage(weapon.player.playerStatistic.currentAttack);
            }
        }
    }

    protected override void Start()
    {
        base.Start();

        hitBox = GetComponent<ActionHitbox>();
        weapon = GetComponent<Weapon>();

        hitBox.OnDetectedCollider2D += HandleDetectCollider2D;
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        hitBox.OnDetectedCollider2D -= HandleDetectCollider2D;
    }
}
