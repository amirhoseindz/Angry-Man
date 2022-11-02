using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]public List<Transform> visibleTargets = new List<Transform>();
    
    private void Start()
    {
        StartCoroutine("FindTargetsWithDelay", 0.5f);
    }

    IEnumerator FindTargetsWithDelay(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindVisibleTargets();
        }
    }
    
    private void FindVisibleTargets()
    {
        visibleTargets.Clear();
        
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++)
        {
            Transform target = targetsInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                float disToTarget = Vector3.Distance(transform.position, target.position);
                if (!Physics.Raycast(transform.position, dirToTarget, disToTarget, obstacleMask))
                {
                    visibleTargets.Add(target);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angelInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angelInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angelInDegrees * Mathf.Deg2Rad), 0,
            Mathf.Cos(angelInDegrees * Mathf.Deg2Rad));
    }
    
    
}
