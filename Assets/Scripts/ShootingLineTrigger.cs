using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingLineTrigger : MonoBehaviour
{
    public GameObject player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            var _player = player.GetComponent<ProjectileMover>();
            _player.playerOnEndLine = true;   
        }
    }
}
