﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);

        }

    }

    // Update is called once per frame
    void Update () {
		
	}
}
