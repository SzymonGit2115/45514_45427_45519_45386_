using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] float velocity;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] float damage;

    private void Awake()
    {
        rigidbody.velocity = transform.forward* velocity;
        Destroy(gameObject, 5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        var damagables = collision.collider.GetComponentsInParent<IDamagable>();

        if (damagables.Length == 0)
        {
            return;
        }

        foreach (var damagable in damagables)
        {
            damagable.AddDamage(damage);

        }

    }
}
