using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject playerGun;
    public GameObject enemyGun;
    private ProjectileMover _player;

    private void Start()
    {
        _player = player.GetComponent<ProjectileMover>();
    }


    void Update()
    {
        if (_player.playerOnEndLine)
        {
            playerGun.SetActive(true);
            enemyGun.SetActive(false);
        }
    }
}
