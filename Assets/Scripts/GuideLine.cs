using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideLine : MonoBehaviour
{
    public int numPoints = 12;
    public float timeBetweenPoints = 0.1f;
    public LayerMask collideAbleLayers;
    
    private ProjectileMover _character;
    private LineRenderer _guidLine;
    [SerializeField] int characterColliderOverlapsRadios = 2;
    void Start()
    {
        _character = GetComponent<ProjectileMover>();
        _guidLine = GetComponent<LineRenderer>();
    }

    void Update()
    {
        _guidLine.positionCount = numPoints;
        List<Vector3> points = new List<Vector3>();
        Vector3 startingPosition = _character.launchDirection.position;
        Vector3 startVelocity = _character.launchDirection.forward.normalized * _character.launchForce;

        for (float t = 0; t < numPoints; t += timeBetweenPoints)
        {
            Vector3 newPoints = startingPosition + t * startVelocity;
            newPoints.y = startingPosition.y + startVelocity.y * t + Physics.gravity.y / 2f * t * t;
            points.Add(newPoints);
        }
        _guidLine.SetPositions(points.ToArray());
    }
}
