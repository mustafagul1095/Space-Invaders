using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyBullet bulletPrefab;
    [SerializeField] private Vector3 leftBulletInitPos = new Vector3(-2f, -6.5f,0);
    [SerializeField] private Vector3 rightBulletInitPos = new Vector3(2f, -6.5f,0);

    [SerializeField] private Vector3 offsetA = new Vector3();
    [SerializeField] private Vector3 offsetB = new Vector3();

    [SerializeField] private float speed = 5f;

    [SerializeField] private GameObject explosionPrefab;
    
    private Vector3 _pointA;
    private Vector3 _pointB;
    
    private Enemies _enemies;

    private void Start()
    {
        _enemies = GetComponentInParent<Enemies>();
        _pointA = transform.position + offsetA;
        _pointB = transform.position + offsetB;
    }

    private void Update()
    {
        transform.position = Vector3.Lerp (_pointA, _pointB, Mathf.PingPong(Time.time*speed, 1.0f));
    }

    public void Shoot()
    {
        var position = transform.position;
        Vector3 leftBulletSpawnPos = position + leftBulletInitPos;
        Vector3 rightBulletSpawnPos = position + rightBulletInitPos;
        Instantiate(bulletPrefab, leftBulletSpawnPos, Quaternion.identity);
        Instantiate(bulletPrefab, rightBulletSpawnPos, Quaternion.identity);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PlayerBullet"))
        {
            EnemyHit(other);
        }
    }

    private void EnemyHit(Collider other)
    {
        _enemies.RemoveFromEnemyList(this);
        var go = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        
        Destroy(go,1);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
