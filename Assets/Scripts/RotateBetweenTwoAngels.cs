using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBetweenTwoAngels : MonoBehaviour
{
    [SerializeField] private Transform GroundSideEdge;
    [SerializeField] private float RotationSpeed;

    void Update()
    {
        Vector3 direction = GroundSideEdge.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 300;

        transform.rotation = Quaternion.Euler(0, Mathf.PingPong(Time.time * RotationSpeed , 120) - angle, 0);
    }
}
