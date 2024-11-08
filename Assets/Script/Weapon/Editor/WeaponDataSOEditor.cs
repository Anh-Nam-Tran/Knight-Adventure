using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.Callbacks;
using UnityEngine;

[CustomEditor(typeof(WeaponDataSO))]
public class WeaponDataSOEditor : Editor
{   
    private static List<Type> dataCompTypes = new List<Type>();
    private WeaponDataSO dataSO;

    private bool showForceUpdateButtons;
    private bool showAddComponentButtons;

    private void OnEnable()
    {
        dataSO = target as WeaponDataSO;
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Set Number of Attacks"))
        {
            foreach (var item in dataSO.ComponentData)
            {
                item.InitializeAttackData(dataSO.NumberOfAttacks);
            }
        }

        showAddComponentButtons = EditorGUILayout.Foldout(showAddComponentButtons, "Add Components");

        if (showAddComponentButtons)
        {
            foreach (var dataCompType in dataCompTypes)
            {
                if (GUILayout.Button(dataCompType.Name))
                {
                    var comp = Activator.CreateInstance(dataCompType) as ComponentData;

                    if (comp == null)
                    {
                        return;
                    }

                    comp.InitializeAttackData(dataSO.NumberOfAttacks);

                    dataSO.AddData(comp);
                }
            }
        }

        showForceUpdateButtons = EditorGUILayout.Foldout(showForceUpdateButtons, "Force Update Buttons");

        if (showForceUpdateButtons)
        {
            if (GUILayout.Button("Force Update Component Name"))
            {
                foreach (var item in dataSO.ComponentData)
                {
                    item.SetComponentName();
                }
            }

            if (GUILayout.Button("Force Update Attack Name"))
            {
                foreach (var item in dataSO.ComponentData)
                {
                    item.SetAttackDataName();
                }
            }
        }
    }

    [DidReloadScripts]
    private static void OnRecompile()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        var types = assemblies.SelectMany(assembly => assembly.GetTypes());
        var filterTypes = types.Where(
            type => type.IsSubclassOf(typeof(ComponentData))  && !type.ContainsGenericParameters && type.IsClass
        );
        dataCompTypes = filterTypes.ToList();
    }
}
