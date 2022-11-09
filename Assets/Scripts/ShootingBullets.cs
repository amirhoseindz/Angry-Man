using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class ShootingBullets : MonoBehaviour
{
    public GameObject Projectile;
    public GameObject Target;
    
    [SerializeField] private Transform FirePoint;
    [SerializeField] private float FireForce;

    public void Shoot()
    {
        Rigidbody bullet = Instantiate(Projectile, FirePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        Vector3 direction = Target.transform.position - FirePoint.position;
        direction = direction.normalized;
        bullet.velocity = direction * FireForce;
    }
}
