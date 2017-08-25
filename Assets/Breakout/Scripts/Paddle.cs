using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Breakout
{

    public class Paddle : MonoBehaviour
    {

        public float movementSpeed = 20f;
        public Ball currentBall;

        // Directions array defaults to two values
        public Vector2[] directions = new Vector2[]
        {
            new Vector2(-0.5f,0.5f),// index 0
            new Vector2(0.5f,0.5f) // index 1
        };

        // Use this for initialization
        void Start()
        {
            // Grabs currentBall from children of Paddle
            currentBall = GetComponentInChildren<Ball>();
        }

       void Fire()
        {
            // Detach children(Ball)
            currentBall.transform.SetParent(null);
            // Randomly select a direction
            Vector3 ramdomDir = directions[Random.Range(0, directions.Length)];
            // Fire off the ball in the random direction
            currentBall.Fire(ramdomDir);
        }

        void CheckInput()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Fire();
            }
        }

        void Movement()
        {
            // Get input axis horizontal
            float inputH = Input.GetAxis("Horizontal");
            // Set force to direction (inputH to decide which direction)
            Vector3 force = transform.right * inputH;
            // Apply movement speed to force
            force *= movementSpeed;
            // Apply deltaTime to force
            force *= Time.deltaTime;
            // Add force to position
            transform.position += force;
        }

        // Update is called once per frame
        void Update()
        {
            CheckInput();
            Movement();
        }
    }
}
