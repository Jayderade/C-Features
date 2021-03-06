﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{
    public class Charger : Enemy
    {
        [Header("Charger")]
        public float impactForce = 10f;
        public float knockback = 5f;
                      
        protected override void Awake()
        {
            base.Awake();                    
        }

        protected override void Attack()
        {
            
            // Add force to self 
            rigid.AddForce(-transform.forward * knockback);
        }

        void OnCollisionEnter(Collision col)
        {            
            Health h = GetComponent<Health>();
            // If collision hits player
            if(col.gameObject.name == "Player")
            {
                col.rigidbody.AddForce(transform.forward * impactForce);                
            }              
        }       
    }
}
