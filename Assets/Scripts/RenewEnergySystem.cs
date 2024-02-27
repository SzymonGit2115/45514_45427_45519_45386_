using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenewEnergySystem : MonoBehaviour
{
    [SerializeField] SOFloatVariable energy;
    [SerializeField] SOFloatVariable energyMax;
    [SerializeField] GameObject player;

    private void Start()
    {
        energy.Variable.Value = energyMax.Variable.Value;
    }

    private void OnTriggerStay(Collider other)
    {
        var isEnergyMax = energy.Variable.Value >= energyMax.Variable.Value;

        if (other.name == "Player" && !isEnergyMax)
        {
            OnValueChanged();
        }
    }

    private void OnValueChanged()
    {           
        Debug.Log("PlayerRenewEnergy");

        energy.Variable.Value ++;
    }
}
