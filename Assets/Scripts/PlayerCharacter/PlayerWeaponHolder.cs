using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponHolder : MonoBehaviour
{
    //[SerializeField] List<GameObject> weapons;
    [SerializeField] Queue<WeaponController> weapons = new ();
    WeaponController currentWeapon;

    private void Awake()
    {
        foreach (Transform child in transform) 
        {
            if(child == transform) continue;    

            child.gameObject.SetActive(false);
            weapons.Enqueue(child.gameObject.GetComponent<WeaponController>());
        
        }

        SelectNextWeapon();
    }

    private void SelectNextWeapon()
    {
        if(currentWeapon)
        {
            currentWeapon.gameObject.SetActive(false);
            weapons.Enqueue(currentWeapon);
        }

        currentWeapon = weapons.Dequeue();
        currentWeapon.gameObject.SetActive(true);

    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
            SelectNextWeapon();

        if (Input.GetMouseButton(0))
            currentWeapon.Shoot();

    }
}
