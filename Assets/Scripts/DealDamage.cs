using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField] private int damageAmount;
    [SerializeField] private bool destroyAfterHit;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Health>() != null)
        {
            var healthComponent = collision.gameObject.GetComponent<Health>();
            healthComponent.TakeDamage(damageAmount);
        }

        if (destroyAfterHit)
        {
            gameObject.SetActive(false);
        }
    }
}
