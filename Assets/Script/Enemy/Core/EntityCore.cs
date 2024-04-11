using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCore : MonoBehaviour
{
    public EntityMovement EntityMovement
    {
        get => GenericNotImplementedError<EntityMovement>.TryGet(entityMovement, transform.parent.name);
        private set => entityMovement = value;
    }
    public EntityCollisionSenses EntityCollisionSenses
    {
        get => GenericNotImplementedError<EntityCollisionSenses>.TryGet(entityCollisionSenses, transform.parent.name);
        private set => entityCollisionSenses = value;
    }
    public EntityCombat EntityCombat
    {
        get => GenericNotImplementedError<EntityCombat>.TryGet(entityCombat, transform.parent.name);
        private set => entityCombat = value;
    }

    public EntityResource EntityResource
    {
        get => GenericNotImplementedError<EntityResource>.TryGet(entityResource, transform.parent.name);
        private set => entityResource = value;
    }

    public EntityMovement entityMovement;
    public EntityCollisionSenses entityCollisionSenses;
    public EntityCombat entityCombat;
    public EntityResource entityResource;

    private void Awake()
    {
        EntityMovement = GetComponentInChildren<EntityMovement>();
        EntityCollisionSenses = GetComponentInChildren<EntityCollisionSenses>();
        EntityCombat = GetComponentInChildren<EntityCombat>();
        EntityResource = GetComponentInChildren<EntityResource>();
    }

    public void Start()
    {
        EntityResource.currentHealth = EntityResource.entityStat.currentHealth;
        EntityResource.currentStamina = EntityResource.entityStat.currentStamina;
        EntityResource.currentStance = EntityResource.entityStat.currentStance;
    }

    public void LogicUpdate()
    {
        EntityMovement.LogicUpdate();
        EntityCombat.LogicUpdate();
        EntityResource.LogicUpdate();
    }

}
