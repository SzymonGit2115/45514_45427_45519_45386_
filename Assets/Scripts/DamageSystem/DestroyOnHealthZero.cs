using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnHealthZero : MonoBehaviour
{
    [SerializeField] private bool destroyOnZeroHP;
    [SerializeField] private bool resetHP;
    [SerializeField] private bool teleport;

    [SerializeField] HealthComponent healthComponent;

    private Dictionary<bool, Action> actionMap = new Dictionary<bool, Action>();

    private void Awake()
    {
        healthComponent.Health.OnValueChanged += OnHealthChanged;

        actionMap[destroyOnZeroHP] = DestroyOnZero;
        actionMap[resetHP] = ResetHP;
        actionMap[teleport] = Teleport;
    }

    private void OnDestroy()
    {
        healthComponent.Health.OnValueChanged -= OnHealthChanged;

    }

    private void OnHealthChanged(float lastValue)
    {
        if(lastValue > 0 && healthComponent.Health.Value <= 0) 
        {
            ExecuteMethodsBasedOnFlags();
        }
    }

    private void Reset()
    {
        healthComponent = GetComponent<HealthComponent>();
    }

    private void ExecuteMethodsBasedOnFlags()
    {
        foreach (var entry in actionMap)
        {
            if (entry.Key)
            {
                entry.Value.Invoke();
            }
        }
    }


    private void DestroyOnZero()
    {
        Destroy(gameObject);
    }

    private void ResetHP()
    {
        healthComponent.Health.Value = healthComponent.HealthMax.Value;
    }

    private void Teleport()
    {
        float lowerLimit = -10.0f;
        float upperLimit = 10.0f;

        float randomX = UnityEngine.Random.Range(lowerLimit, upperLimit);
        float randomZ = UnityEngine.Random.Range(lowerLimit, upperLimit);

        transform.position = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        ResetHP();
    }


}
