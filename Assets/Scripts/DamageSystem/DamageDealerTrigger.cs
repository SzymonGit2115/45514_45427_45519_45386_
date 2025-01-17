using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerTrigger : MonoBehaviour
{
    [SerializeField] float damagePerSecond;


    
    private void OnTriggerStay(Collider other)
    {


        var damagables = other.GetComponentsInParent<IDamagable>();
        if (damagables.Length == 0)
            return;

        var damage = damagePerSecond * Time.fixedDeltaTime;

        foreach (var damagable in damagables)
        {
            damagable.AddDamage(damage);
        }

    }
}


