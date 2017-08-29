using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Breakout
{
    public class Ball : MonoBehaviour
    {
        public float speed = 5f;
        public Text countText;
        

        private int count;
        private Vector3 velocity;

        // Send ball flying in a given direction
        public void Fire(Vector3 direction)
        {
            velocity = direction * speed;
        }
        
        void OnCollisionEnter2D(Collision2D other)
        {
            // Grab comtact point of collision
            ContactPoint2D contact = other.contacts[0];
            // Calculate the reflection point using velocity and contact normal
            Vector3 reflect = Vector3.Reflect(velocity, contact.normal);
            // Calculate new velocity from reflection multiply by same speed (velocity.magnitude)
            velocity = reflect.normalized * velocity.magnitude;

            if (other.gameObject.CompareTag("Boxes"))
            {
                count = count + 1;
                SetCountText();
            }
        }

        
                       
        // Use this for initialization
        void Start()
        {
            count = 0;
            SetCountText();
        }

        // Update is called once per frame
        void Update()
        {
            // Moves ball using velocity and deltaTime
            transform.position += velocity * Time.deltaTime;
        }

        

        void SetCountText()
        {
            countText.text = "Score:" + count.ToString();
        }

    }
}