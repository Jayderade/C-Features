using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inheritance
{

    public class Splodey : Enemy
    {
        [Header("Splodey")]
        public float splosionRadius = 5f;
        public float splosionRate = 3f;
        public float impactForce = 10f;
        public GameObject splosionParticles;

        private float splosionTimer = 0f;

        public override void Attack()
        {
            // Start ignition timer
            splosionTimer++;
            // If splotionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                // Call Explode()
                Explode(transform.position);
            }
        }

        void Explode(Vector3 center)
        {
            // Perform Physics OverlapSphere
            Collider[] hitColliders = Physics.OverlapSphere(center, splosionRadius);
            // Loop though all hits
            foreach (Collider hitCol in hitColliders)
            {
                // if player
                if (hitCol.gameObject.name == "Player")
                {
                    // Add impact force to rigidbody
                    hitCol.GetComponent<Rigidbody>().AddExplosionForce(impactForce, center, splosionRadius);
                }
                // Destroy self
                Destroy(gameObject);
            }


        }
    }
}