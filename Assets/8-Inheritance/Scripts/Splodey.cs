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

        protected override void Update()
        {
            base.Update();

            splosionTimer += Time.deltaTime;
        }
        protected override void OnAttackEnd()
        {
            // If splotionTimer > splosionRate
            if (splosionTimer > splosionRate)
            {
                // Call Explode()
                Splode();
                Destroy(gameObject);
            }
        }
        

        void Splode()
        {
            // Perform Physics OverlapSphere
            Collider[] hits = Physics.OverlapSphere(transform.position, splosionRadius);
            // Loop though all hits
            foreach (var hit in hits)
            {
                // if player
                if (hit.gameObject.name == "Player")
                {
                    Health h = hit.GetComponent<Health>();
                    if (h != null)
                    {
                        h.TakeDamage(damage);                       
                    }
                    Rigidbody r = hit.GetComponent<Rigidbody>();
                    if(r != null)
                    {
                        
                        r.AddExplosionForce(impactForce,transform.position,splosionRadius);
                    }
                }
            }
        }
    }
}