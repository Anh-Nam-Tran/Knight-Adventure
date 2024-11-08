using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newEntityData", menuName = "Data/Entity Data/Base Data")]
public class D_Entity : EntityStat
{

    [Header("Terrain Check")]
    public float wallCheckDistance = 0.2f;
    public float ledgeCheckDistance = 0.4f;
    public float groundCheckRadius = 0.3f;

    [Header("Aggro")]
    public float minAgroDistance = 3f;
    public float maxAgroDistance = 4f;

    [Header("Stance")]
    public float stunRecoveryTime = 2f;

    [Header("Action Distance")]
    public float closeRangeActionDistance = 1f;

    public GameObject hitParticle;

    public LayerMask whatIsGround;
    public LayerMask whatIsPlayer;
}
