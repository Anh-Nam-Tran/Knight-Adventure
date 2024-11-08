using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WeaponSpriteData : ComponentData<AttackSprite>
{
    public WeaponSpriteData()
    {
        ComponentDependency = typeof(WeaponSprite);
    }
}
