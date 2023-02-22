using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = System.Random;

public class Enemies : MonoBehaviour
{
    [SerializeField] private float enemyShootingTime = 1f;
    private float _time = 0;
    private Enemy[] _enemies;
    private readonly List<Enemy> _enemyList = new List<Enemy>();

    private void Awake()
    {
        _enemies = GetComponentsInChildren<Enemy>();
        foreach (var enemy in _enemies)
        {
            _enemyList.Add(enemy);
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;
        if (_time >= enemyShootingTime)
        {
            RandomEnemyShoot();
            _time = 0;
        }

        CheckPlayerWins();
    }

    private void CheckPlayerWins()
    {
        if (_enemyList.Count <= 0)
        {
            PlayerWins();
        }
    }

    private void PlayerWins()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);    }

    private void RandomEnemyShoot()
    {
        Random rnd = new Random();
        _enemyList[rnd.Next(0, _enemyList.Count)]?.Shoot();
    }

    public void RemoveFromEnemyList(Enemy enemy)
    {
        _enemyList.Remove(enemy);
    }
}
