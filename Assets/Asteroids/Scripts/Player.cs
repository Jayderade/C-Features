﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//How to clean up code:
// Step 1). CTRL+A (Highlight all code)
// Step 2). CTRL+K+D (In that order

// Highlight multiple lines:
// SHIFT+ALT+(UP or DOWN Arrows)


public class Player : MonoBehaviour
{
    // <access-specifier> <data-type> <variable-name>
    public int lives = 3;
    public float rotationSpeed = 2;
    public float movementspeed = 5;
    public float acceleration = 50f;
    public float deceleration = .1f;

    // Objects default to 'null'
    private Rigidbody2D rigid;
    
    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if user presses W         
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            // Move Right 
            rigid.AddForce(transform.right * acceleration);

        }
        // if user presses S
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            // Move Left 
            rigid.AddForce(-transform.right * acceleration);

        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed,Vector3.forward);

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.back);

        // Deceleration
        rigid.velocity = rigid.velocity + -rigid.velocity * deceleration;
    }
   
}
