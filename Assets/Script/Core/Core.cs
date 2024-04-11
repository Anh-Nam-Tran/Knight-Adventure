using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Core : MonoBehaviour
{
    public Movement Movement
    {
        get => GenericNotImplementedError<Movement>.TryGet(movement, transform.parent.name);
        private set => movement = value;
    }
    public CollisionSenses CollisionSenses
    {
        get => GenericNotImplementedError<CollisionSenses>.TryGet(collisionSenses, transform.parent.name);
        private set => collisionSenses = value;
    }
    public Combat Combat
    {
        get => GenericNotImplementedError<Combat>.TryGet(combat, transform.parent.name);
        private set => combat = value;
    }

    public Resource Resource
    {
        get => GenericNotImplementedError<Resource>.TryGet(resource, transform.parent.name);
        private set => resource = value;
    }

    private Movement movement;
    private CollisionSenses collisionSenses;
    private Combat combat;
    private Resource resource;

    private void Awake()
    {
        Movement = GetComponentInChildren<Movement>();
        CollisionSenses = GetComponentInChildren<CollisionSenses>();
        Combat = GetComponentInChildren<Combat>();
        Resource = GetComponentInChildren<Resource>();
    }

    public void Start()
    {
        Resource.currentHealth = Resource.playerStat.currentHealth;
        Resource.currentStamina = Resource.playerStat.currentStamina;
        Resource.healthBar.SetMaxValue(Combat.playerStat.maxHealth);
        Resource.staminaBar.SetMaxValue(Combat.playerStat.maxStamina);
    }

    public void LogicUpdate()
    {
        Movement.LogicUpdate();
        Combat.LogicUpdate();
        Resource.LogicUpdate();
    }

}
