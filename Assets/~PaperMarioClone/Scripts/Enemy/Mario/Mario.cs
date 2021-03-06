﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace PaperMarioClone
{
    [RequireComponent(typeof(PlayerController))]
    public class Mario : MonoBehaviour
    {
        public float rayDistance;

        private PlayerController pC;
        private Ray stompRay;

        void Awake()
        {
            pC = GetComponent<PlayerController>();
        }

        void RecalculateRay()
        {
            stompRay = new Ray(transform.position, Vector3.down);
        }

        void OnDrawGizmos()
        {
            RecalculateRay();
            Gizmos.color = Color.green;
            Gizmos.DrawLine(stompRay.origin, stompRay.origin + stompRay.direction * rayDistance);
        }

        void CheckStomp()
        {
            // Perform raycast
            RaycastHit hit;
            if (Physics.Raycast(stompRay, out hit, rayDistance))
            {
                // Are we on top of enemy
                Enemy e = hit.collider.GetComponent<Enemy>();
                if (e != null)
                {
                    // Add force up
                    e.Damage();
                    pC.Jump(true);
                }
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            CheckStomp();
        }
    }
}
