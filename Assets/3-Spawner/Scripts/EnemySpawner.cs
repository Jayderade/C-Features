using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Classes
{

    public class EnemySpawner : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public float spawnRate = 1f;
        public float spawnRadius = 1f;
        public float force = 20f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,spawnRadius);
        }

        // Use this for initialization
        void Start()
        {            
            Invoke("Spawn", spawnRate);
        }

       
        void Spawn()
        {
            // Instantiate a new GameObject
            GameObject enemy = Instantiate(enemyPrefab);
            //Position it to a random place within the screen
            enemy.transform.position = Random.insideUnitCircle * spawnRadius;
            // Apply force to rigidbody randomly
            Rigidbody2D rigid2D = enemy.GetComponent<Rigidbody2D>();
            rigid2D.AddForce(Random.insideUnitCircle * force);
        }
    }
}
