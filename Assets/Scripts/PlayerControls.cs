using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float speed = 50;
    [SerializeField] private float rottionSpeed = 0.01f;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector3(-speed, 0, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0,45,0), rottionSpeed );
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector3(speed, 0, 0);
            rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.Euler(0,-45,0), rottionSpeed );
        }
        else
        {
            rb.velocity = new Vector3(0, 0, 0);
            rb.rotation = Quaternion.Euler(0,0,0);
        }
    }
    
    
}
