using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject projectile;
    public GameObject target;
    
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireForce;

    
    private void Update()
    {
        if (gameObject.CompareTag("PlayerGun") && Input.GetKeyUp(KeyCode.A)) 
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Rigidbody bullet = Instantiate(projectile, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        Vector3 direction = target.transform.position - firePoint.position;
        direction = direction.normalized;
        bullet.velocity = direction * fireForce;
    }
}
