﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TowerDefense
{
    public class Tower : MonoBehaviour
    {

        public Cannon cannon; // Reference to cannon inside tower
        public float attackRate = 0.25f; // Rate of attack in world units
        public float attackRadius = 5f; // Distance of attack in world units

        private float attackTimer = 0f; // Timer to count up to attackRate
        private List<Enemy> enemies = new List<Enemy>(); // List of enemies whithin radius

        void OnTriggerEnter(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();

            if(e != null)
            {
                enemies.Add(e);
            }
        }

        void OnTriggerExit(Collider col)
        {
            Enemy e = col.GetComponent<Enemy>();

            if(e != null)
            {
                enemies.Remove(e);
            }
        }

        Enemy GetClosestEnemy()
        {
            Enemy closest = null;

            float minDistance = float.MaxValue;

            for(int i = 0; i <= enemies.Count; i++)
            {
                 float distance = 0;
                if(distance < minDistance)
                {
                    minDistance = distance;
                    closest = enemies[i];
                }
            }
            return closest;
        }

        void Attack()
        {
            Enemy closest = GetClosestEnemy();

            if(closest != null)
            {
                cannon.Fire(closest);
            }
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            attackTimer = attackTimer + Time.deltaTime;

            if (attackTimer >= attackRate)
            {
                Attack();
                attackTimer = 0;
            }
        }
    }
}