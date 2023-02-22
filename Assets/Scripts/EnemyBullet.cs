using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed = 50f;
    [SerializeField] private float bulletDestroyTime = 5f;
    private float _time = 0;
    private void Update()
    {
        MoveBullet();
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        _time += Time.deltaTime;
        if (_time >= bulletDestroyTime)
        {
            _time = 0;
            Destroy(gameObject);
        }
    }

    private void MoveBullet()
    {
        transform.Translate(Vector3.down * (speed * Time.deltaTime));
    }
}
