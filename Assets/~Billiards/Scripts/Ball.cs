using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Billiards
{
    [RequireComponent(typeof(Rigidbody))]
    public class Ball : MonoBehaviour
    {
        public float stopSpeed = 0.2f;
        public GameObject cue;
        public Rigidbody rigid;
        public Ball cueBall;        

        // Use this for initialization
        void Start()
        {
            rigid = GetComponent<Rigidbody>();           
        }

        
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            // Check if velocity is going up
            if(vel.y >0)
            {
                // Cap velocity
                vel.y = 0;
                cue.SetActive(true);
            }

            // If the velocity's speed is less than the stop speed
            // If velocity.magnitude < stopSpeed
            if(vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;
            }
            // Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;
        }

        // Perform physics impact
        public void Hit(Vector3 dir, float impactForce)
        {
            rigid.AddForce(dir * impactForce, ForceMode.Impulse);
        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Pocket"))
            {
                Destroy(gameObject);                
            }
        }      
        
    }
}
