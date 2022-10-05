using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float jumpForce = 7f;
    public CapsuleCollider col;
    public LayerMask groundLayer;
    public Transform rightLaunchDirection;
    public Transform leftLaunchDirection;
    public float launchForce = 350f;

    private Rigidbody _rb;
    private Transform _launchDirection;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            LaunchPlayer();
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * 0.99f, groundLayer);
    }

    private void LaunchPlayer()
    {
        if (transform.position.x >= 0)
        {
            _launchDirection = rightLaunchDirection;
        }
        else
        {
            _launchDirection = leftLaunchDirection;
        }

        Vector3 launchDir = new Vector3(_launchDirection.position.x - transform.position.x,
            _launchDirection.position.y - transform.position.y, _launchDirection.position.z - transform.position.z);
        _rb.AddForce(launchDir * launchForce);
    }
}
