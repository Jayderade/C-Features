﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using GGL;

namespace MOBA
{
    [RequireComponent(typeof(Camera))]
    public class AIAgentPatrolSelecter : MonoBehaviour
    {
        public LayerMask hitLayers;
        public float rayDistance = 1000f;
        public AIAgent[] agentsToDirect;

        public List<Transform> patrolPoints;

        private Camera cam;


        // Use this for initialization
        void Start()
        {
            cam = GetComponent<Camera>();

            // Loop through and assign patrol selector to all agents
            foreach (var agent in agentsToDirect)
            {
                Patrol p = agent.GetComponent<Patrol>();
                if(p != null)
                {
                    p.patrolSelector = this;
                }
            }
        }

        // Update is called once per frame
        void Update()
        {
            HandleSelector();
            foreach (var p in patrolPoints)
            {
                GizmosGL.AddSphere(p.position, 1f);
            }
        }

        void HandleSelector()
        {
            if(Input.GetMouseButtonDown(1))
            {
                Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit rayHit;

                if(Physics.Raycast(camRay, out, rayHit, rayDistance, hitLayers))
                {
                    NavMeshHit navHit;
                    if(NavMesh.SamplePosition(rayHit.point, out navHit, rayDistance, -1))
                    {
                        AddPatrolPoint(rayHit.point);
                    }
                }
            }
        }

        void AddPatrolPoint(Vector3 point)
        {
            GameObject g = new GameObject("Point" + patrolPoints.Count);
            g.transform.position = point;
            patrolPoints.Add(g.transform);
        }

    }
}
