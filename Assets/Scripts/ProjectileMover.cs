using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Rendering;

public class ProjectileMover : MonoBehaviour
{
    public CapsuleCollider col;
    public LayerMask groundLayer;
    public Transform launchDirection;
    public float launchForce;

    private Rigidbody _rb;
    private float minLaunchForce = 7f;
    private float maxLaunchForce = 10f;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            launchForce = minLaunchForce;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (launchForce < maxLaunchForce)
            {
                launchForce += 1.5f * Time.deltaTime;
            }
        }
        if (IsGrounded() && Input.GetKeyUp(KeyCode.Space))
        {
            LaunchPlayer();
            launchForce = minLaunchForce;
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * 0.99f, groundLayer);
    }

    private void LaunchPlayer()
    {
        _rb.velocity = (launchDirection.forward * launchForce);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, launchDirection.forward);
    }
}
