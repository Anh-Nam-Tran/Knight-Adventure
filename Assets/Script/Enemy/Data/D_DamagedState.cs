using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newDamagedStateData", menuName = "Data/State Data/Damaged State")]
public class D_DamagedState : ScriptableObject
{
    public float knockbackForce = 10f;
}
