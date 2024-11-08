using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class ComponentData
{
    [SerializeField, HideInInspector] private string name;

    public Type ComponentDependency { get; protected set; }

    public ComponentData()
    {
        SetComponentName();
    }

    public void SetComponentName() => name = GetType().Name;

    public virtual void SetAttackDataName() {}

    public virtual void InitializeAttackData(int numberOfAttacks) {}
}

[Serializable]
public class ComponentData<T> : ComponentData where T : AttackData
{
    [SerializeField] private T[] attackData;
    public T[] AttackData { get => attackData; private set => attackData = value; }

    public override void SetAttackDataName()
    {
        base.SetAttackDataName();

        for (int i = 0; i < AttackData.Length; i++)
        {
            AttackData[i].SetAttackName(i+1);
        }
    }

    public override void InitializeAttackData(int numberOfAttacks) 
    {
        base.InitializeAttackData(numberOfAttacks);

        var oldLen = attackData != null ? attackData.Length : 0;

        if (oldLen == numberOfAttacks)
        {
            return;
        }

        Array.Resize(ref attackData, numberOfAttacks);

        if (oldLen < numberOfAttacks)
        {
            for (var i = oldLen; i < attackData.Length; i++)
            {
                var newObj = Activator.CreateInstance(typeof(T)) as T;
                attackData[i] = newObj;
            }
        }

        SetAttackDataName();
    }
}
