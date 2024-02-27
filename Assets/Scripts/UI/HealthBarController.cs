using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    [SerializeField] Canvas canvas;
    [SerializeField] Slider slider;

    [Header("To Override In Other Prefab")]
    [SerializeField] HealthComponent healthComponent;

    Coroutine hideCorutine;

    private void Awake()
    {
        healthComponent.Health.OnValueChanged += OnHealthChanged;
        healthComponent.Health.OnValueChanged += HideOnInitialize;

    }

    private void HideOnInitialize(float obj)
    {
        canvas.enabled = false;
        healthComponent.Health.OnValueChanged -= HideOnInitialize;
    }

    private void OnDestroy()
    {
        healthComponent.Health.OnValueChanged -= OnHealthChanged;

    }

    private void OnHealthChanged(float oldValue)
    {
        slider.value = healthComponent.Health.Value / healthComponent.HealthMax.Value;
        canvas.enabled = true;

        if(hideCorutine != null ) StopCoroutine( hideCorutine);
        hideCorutine = StartCoroutine(Hide(3f));
    }

    IEnumerator Hide(float timer)
    {
        yield return new WaitForSeconds(timer);
        canvas.enabled= false;
    }
}
