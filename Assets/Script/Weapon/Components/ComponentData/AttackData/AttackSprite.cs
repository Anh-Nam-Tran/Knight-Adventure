using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


[Serializable]
public class AttackSprite : AttackData
{
    [field: SerializeField] public Sprite[] Sprites { get; private set; }
}
