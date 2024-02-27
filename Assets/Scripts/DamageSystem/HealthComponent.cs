using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour, IDamagable
{

    [field : SerializeField] public EventableType<float> Health { get; private set; }
    [field: SerializeField] public EventableType<float> HealthMax { get; private set; }

    [Header("Variable")]
    [SerializeField] SOFloatVariable variableHealth;
    [SerializeField] SOFloatVariable variableHealthMax;

    private void Awake()
    {
        Health.Value = HealthMax.Value;


         if (variableHealth)
         {
             Health.OnValueChanged += (old) => variableHealth.Variable.Value = Health.Value;
             variableHealth.Variable.Value = Health.Value;
        
         }
         if (variableHealthMax)
         {
             HealthMax.OnValueChanged += (old) => variableHealthMax.Variable.Value = HealthMax.Value;
             variableHealthMax.Variable.Value = HealthMax.Value;
         }
    }

    public void AddDamage(float damage)
    {
        Health.Value -= damage;
    }


   



#if UNITY_EDITOR

    [Header("Debug Health")]
    [SerializeField] private float debugHealthDiff;

    [ContextMenu("Invoke AddDebugHealth")]
    private void InvokeOnHealthChangedEditor()
    {
        Health.Value += debugHealthDiff;

    }
#endif

}
