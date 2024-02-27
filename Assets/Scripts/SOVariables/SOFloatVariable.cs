using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOFloatVariable", menuName = "SOVariables/SOFloatVariable")]



public class SOFloatVariable : ScriptableObject
{
    [SerializeField] public EventableType<float> Variable;
    public Action<float> OnValueChanged;



#if UNITY_EDITOR

    [Header("Debug Value")]
    [SerializeField] private float debugHealthDiff;

    [ContextMenu("Invoke AddDebugValue")]
    private void InvokeOnValueChangedEditor()
    {
        Variable.Value += debugHealthDiff;

    }
#endif
}
