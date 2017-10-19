﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GGL;

namespace AI
{
    [RequireComponent(typeof(AIAgent))]
    public class Seek : SteeringBehaviour // Seek inherits from SteeringBehaviour
    {
        public Transform target;
        public float stoppingDistance = 1f;

        public override Vector3 GetForce()
        {
            // SET force to Vector3 zero
            Vector3 force = Vector3.zero;

            // IF target == null
            if(target == null)
            {
                // return force
                return force;
            }

            // LET desiredForce = target position - transform position
            Vector3 desiredForce = target.position - transform.position;

            // IF desiredForce magnitude > stoppingDistance
            if (desiredForce.magnitude > stoppingDistance)
            {
                // desiredForce = desiredForce normalized x weighting
                desiredForce = desiredForce.normalized * weight;

                // force = desiredForce - owner.velocity
                force = desiredForce - owner.velocity;
            }

            #region GizmosGL
            GizmosGL.color = Color.cyan;
            GizmosGL.AddLine(transform.position, transform.position + desiredForce,0.1f,0.1f);
            GizmosGL.color = Color.gray;
            GizmosGL.AddLine(transform.position, transform.position + force, 0.1f, 0.1f);

            #endregion

            // Return force
            return force;
        }
    }
}
