using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAim : MonoBehaviour
{
    private float _rotationSpeed = 100f;
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Time.deltaTime * _rotationSpeed * Vector3.up);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Time.deltaTime * _rotationSpeed * Vector3.down);
        }
    }
}
