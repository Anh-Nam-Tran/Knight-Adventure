using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCoreComponent : MonoBehaviour
{
    protected EntityCore entityCore;

    protected virtual void Awake()
    {
        entityCore = transform.parent.GetComponent<EntityCore>();

        if(entityCore == null) { Debug.LogError("There is no Core on the parent"); }
    }

}
