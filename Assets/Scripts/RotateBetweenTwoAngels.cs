using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBetweenTwoAngels : MonoBehaviour
{
    [SerializeField] private Transform GroundSideEdge;

    void Update()
    {
        Vector3 direction = GroundSideEdge.position - transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 290;

        transform.rotation = Quaternion.Euler(0, Mathf.PingPong(Time.time * 30 , 150) - angle, 0);
    }
}
