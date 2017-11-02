using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public float shootRate = 0.2f;

    private float shootTimer = 0f;

    void Shoot()
    {
        // Create a new bullet clone
        GameObject clone = Instantiate(bulletPrefab, transform.position, transform.rotation);
        // Grab the Rigidbody2D from the clone
        Rigidbody2D cloneRigid = clone.GetComponent<Rigidbody2D>();
        // Add a force to the bullet (using speed)
        cloneRigid.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Count up shootTimer (in seconds)
        shootTimer += Time.deltaTime;
        // IF shootTimer > shootRate
        if (shootTimer > shootRate)
        {

            // IF space bar is pressed
            if (Input.GetKeyDown(KeyCode.Space))
            {
                // Shoot a projectile
                Shoot();
                // Reset shootTimer
                shootTimer = 0f;
            }
        }
    }
}
