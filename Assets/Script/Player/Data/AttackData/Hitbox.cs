using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    public Combat combat;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Hit!");
            Transform coreTransform = other.transform.Find("Core");

            if (coreTransform != null)
            {
                Transform combatTransform = coreTransform.Find("Combat");

                if (combatTransform != null)
                {
                    EntityCombat entityCombat = combatTransform.GetComponent<EntityCombat>();

                    if (entityCombat != null)
                    {
                        entityCombat.Damage(combat.DealDamage());
                        entityCombat.StanceDamage(combat.DealStanceDamage());
                    }
                }
            }
        }
    }
}
