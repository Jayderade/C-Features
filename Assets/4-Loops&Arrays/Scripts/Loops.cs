using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoopArrays
{



    public class Loops : MonoBehaviour
    {
        public GameObject[] spawnPrefabs;
        public GameObject spawnPrefab;


        public int spawnAmount = 10;
        public float spawnRadius = 5f;

        public float frequency = 5f;
        public float ampitude = 6f;

        public string message = "Print this";

        public float printTime = 2f;
        private float timer = 0;

        void OnDrawGizmos()
        {
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }

        // Use this for initialization
        void Start()
        {
            /*
            while (condition)
            {
             //
             }
             */
            SpawnObjectsWithSine();
        }


        // Update is called once per frame
        void Update()
        {
            //// count up timer in seconds
            //timer += time.deltatime;
            //// loop through until timer gets to printtimer
            //while (timer <= printtime) // stick around
            //{

            //    {
            //        print("put the cookie down!");

            //    }
            //}
                }

        void SpawnObjectsWithSine()
        {
            /*
            for (initialization; condition; interation)
            {
            // Statements(s)
            }
            */


            for (int i = 0; i < spawnAmount; i++)
            {

                // Spawned new GameObject
                int randomIndex = Random.Range(0, spawnPrefabs.Length);

                GameObject randomPrefab = spawnPrefabs[randomIndex];

                GameObject clone = Instantiate(randomPrefab);
                // Grab the MeshRenderer
                MeshRenderer rend = clone.GetComponent<MeshRenderer>();
                // Change the colour
                float r = Random.Range(0, 2);
                float g= Random.Range(0, 2);
                float b= Random.Range(0, 2);
                float a = 1;
                rend.material.color = new Color(r, g, b, a);
                // Generated random position whithin circle (sphere actually)
                float x = Mathf.Sin(i * frequency) * ampitude;
                float y = i;
                float z = Mathf.Cos(i * frequency) * ampitude;
                Vector3 randomPos = transform.position + new Vector3(x,y, z);
               
                // Cancel out the Z
                //randomPos.z = 0;
                // Set spawned object's position
                clone.transform.position = randomPos;
            }
        }

        void SpawnObjects()
        {
            /*
            for (initialization; condition; interation)
            {
            // Statements(s)
            }
            */


            for (int i = 0; i < spawnAmount; i++)
            {
                // Spawned new GameObject
                GameObject clone = Instantiate(spawnPrefab);
                // Generated random position whithin circle (sphere actually)
                Vector3 randomPos = transform.position + Random.insideUnitSphere * spawnRadius;
                // Cancel out the Z
                randomPos.z = 0;
                // Set spawned object's position
                clone.transform.position = randomPos;
                                   
            }
        }
    }
}
