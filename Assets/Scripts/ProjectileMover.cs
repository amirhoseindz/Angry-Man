using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class ProjectileMover : MonoBehaviour
{
    public float jumpForce = 7f;
    public CapsuleCollider col;
    public LayerMask groundLayer;
    public Transform launchDirection;
    public float launchForce = 350f;

    private Rigidbody _rb;
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

        if (IsGrounded() && Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 100f * Time.deltaTime);
        }
        if (IsGrounded() && Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * 100f * Time.deltaTime);
        }
    }

    private bool IsGrounded()
    {
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.min.y,
            col.bounds.center.z), col.radius * 0.99f, groundLayer);
    }

    private void LaunchPlayer()
    {
        Vector3 launchDir = new Vector3(launchDirection.position.x - transform.position.x,
            launchDirection.position.y - transform.position.y, launchDirection.position.z - transform.position.z);
        _rb.AddForce(launchDir * launchForce);
    }
}
