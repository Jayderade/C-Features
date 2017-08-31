using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Billiards
{
    public class CueBall : MonoBehaviour
    {

        public GameObject cue;
        public Rigidbody rigid;
        public float stopSpeed = 0.2f;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        void FixedUpdate()
        {
            Vector3 vel = rigid.velocity;

            if (vel.y < 0)
            {
                cue.SetActive(false);
            }

                // Check if velocity is going up
                if (vel.y > 0)
            {
                // Cap velocity
                vel.y = 0;
                

            }

            // If the velocity's speed is less than the stop speed
            // If velocity.magnitude < stopSpeed
            if (vel.magnitude < stopSpeed)
            {
                // Cancel out velocity
                vel = Vector3.zero;                
            }
            // Apply desired 'vel' to rigid's velocity
            rigid.velocity = vel;

            if(vel == Vector3.zero)
            {
                cue.SetActive(true);
            }
        }
    }
}