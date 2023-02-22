using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private float shootingPeriod = 1f;
    [SerializeField] private Vector3 leftBulletInitPos = new Vector3(-2f, 6.5f,0);
    [SerializeField] private Vector3 rightBulletInitPos = new Vector3(2f, 6.5f,0);
    private float _time = 0f;
    
    private void Update()
    {
        _time += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space))
        {
            if (_time >= shootingPeriod)
            {
                Shoot();
                _time = 0;
            }
        }
    }

    private void Shoot()
    {
        var position = transform.position;
        Vector3 leftBulletSpawnPos = position + leftBulletInitPos;
        Vector3 rightBulletSpawnPos = position + rightBulletInitPos;
        Instantiate(bulletPrefab, leftBulletSpawnPos, Quaternion.identity);
        Instantiate(bulletPrefab, rightBulletSpawnPos, Quaternion.identity);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("EnemyBullet"))
        {
            PlayerHit(other);
        }
    }
    
    private void PlayerHit(Collider other)
    {
        Debug.Log("Player Hit");
        Destroy(other.gameObject);
    }
}
