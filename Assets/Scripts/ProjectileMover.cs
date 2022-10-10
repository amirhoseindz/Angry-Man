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
    public float fallMultiplier = 2.5f;
    public float jumpTime = 0.35f;
    public float jumpTimeCounter;

    private Rigidbody _rb;
    private bool isJumping;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            _rb.velocity = Vector3.up * jumpForce;
            LaunchPlayer();
        }
        if (Input.GetKey(KeyCode.Space) && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                _rb.velocity = Vector3.up * jumpForce;
                LaunchPlayer();
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        //to make the fall feels easier to eye and be more like a gaming jump
        _rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
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
