using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class WeaponSprite : WeaponComponent<WeaponSpriteData, AttackSprite>
{
    private SpriteRenderer baseSpriteRenderer;
    private SpriteRenderer weaponSpriteRenderer;

    private int currentWeaponSpriteIndex;

    protected override void HandleEnter()
    {
        base.HandleEnter();

        currentWeaponSpriteIndex = 0;
    }
    private void HandleBaseSpriteChange(SpriteRenderer sr)
    {
        if (!isAttackActive)
        {
            weaponSpriteRenderer.sprite = null;
            return;
        }

        var currentAttackSprites = currentAttackData.Sprites;

        if (currentWeaponSpriteIndex >= currentAttackSprites.Length)
        {
            Debug.LogWarning("Weapon Sprite length mismatch!");
            return;
        }

        weaponSpriteRenderer.sprite = currentAttackSprites[currentWeaponSpriteIndex];

        currentWeaponSpriteIndex++;
    }
    protected override void Start()
    {
        base.Start();

        baseSpriteRenderer = weapon.BaseGameObject.GetComponent<SpriteRenderer>();
        weaponSpriteRenderer = weapon.WeaponSpriteGameObject.GetComponent<SpriteRenderer>();

        data = weapon.Data.GetData<WeaponSpriteData>();

        baseSpriteRenderer.RegisterSpriteChangeCallback(HandleBaseSpriteChange);
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();

        baseSpriteRenderer.UnregisterSpriteChangeCallback(HandleBaseSpriteChange);

    }
}

