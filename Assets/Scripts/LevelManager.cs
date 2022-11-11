using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject player;
    public GameObject enemy;
    public GameObject playerGun;
    public GameObject enemyGun;

    private ShootingBullets _playerGun;
    private void Start()
    {
        _playerGun = playerGun.GetComponent<ShootingBullets>();
    }

    void Update()
    {
        var _player = player.GetComponent<ProjectileMover>();
        if (_player.playerOnEndLine)
        {
            playerGun.SetActive(true);
            enemyGun.SetActive(false);
            _playerGun.Shoot();
        }
    }
}
