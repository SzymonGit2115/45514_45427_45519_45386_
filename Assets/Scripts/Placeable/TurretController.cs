using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class TurretController : PlaceableController
{
   // [SerializeField] Mesh placeableMesh;

    [Header("Turret Parts")]

    [SerializeField] Transform rotatingTurret;
    [SerializeField] WeaponController weaponController;

    [Header("Turret Settings")]
    [SerializeField] LayerMask layerMask;
    [SerializeField] float radius;

    enum State { SerchingTarget, Shooting}
    State currentState = State.SerchingTarget;
    Transform target;
    readonly Collider[] serchingTargetResults = new Collider[8];


    private void Update()
    {
        switch (currentState) 
        {
            case State.SerchingTarget:
                SerchingTargetUpdate();
                break;

            case State.Shooting:
                ShootingUpdate();
                break;
            default: 
                break;
        
        }
    }

    private void ShootingUpdate()
    {
        if (!CheckIfShootingPossible())
            return;
        
        rotatingTurret.LookAt(target, Vector3.up);
        weaponController.Shoot();


    }

    private bool CheckIfShootingPossible()
    {
        if (!target || Vector3.Distance(rotatingTurret.position, target.position) > radius)
        {
            target = null;
            currentState = State.SerchingTarget;
            return false;

        }

        return true;

    }

    private void SerchingTargetUpdate()
    {      
        var castPosition = rotatingTurret.position;

        var collidersCount = Physics.OverlapSphereNonAlloc(castPosition, radius, serchingTargetResults, layerMask, QueryTriggerInteraction.Ignore);

        if (collidersCount == 0)
            return;


        float closestDistance = Mathf.Infinity;
        Collider closestCollider = null;

        for (int i = 0; i < collidersCount; ++i)
        {
            var collider = serchingTargetResults[i];
            var distance = Vector3.Distance(castPosition, collider.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestCollider = collider;
            }
        }

   

        target = closestCollider.transform;
        currentState = State.Shooting;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(rotatingTurret.position, radius);
    }
}
