using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script depends on the SpriteRenderer component attached to the same GameObject
[RequireComponent(typeof(SpriteRenderer))]
public class Screenwrap : MonoBehaviour
{
    //Sprite
    private SpriteRenderer spriteRenderer;
    //Camera
    private Bounds camBounds;
    private float camWidth;
    private float camHeight;


    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }



    void UpdateCameraBounds()
    {
        // Calculate camera bounds
        Camera cam = Camera.main;
        camHeight = 2f * cam.orthographicSize;
        camWidth = camHeight * cam.aspect;
        camBounds = new Bounds(cam.transform.position, new Vector2(camWidth, camHeight));

    }
    // Use LateUpdate since we are using the camera to wrap objects back around
    void LateUpdate()
    {
        UpdateCameraBounds();
        // Store position and size in shorter variable names
        Vector3 pos = transform.position; // Position of our enemy
        Vector3 size = spriteRenderer.bounds.size; // The size of our enemy
        // Calculate the sprite half width and height
        float halfWidth = size.x / 2f;
        float halfHeight = size.y / 2f;
        float halfCamWidth = camWidth / 2f;
        float halfCamHeight = camHeight / 2f;
        // Check Left
        if (pos.x + halfWidth < camBounds.min.x)
        {
            pos.x = camBounds.max.x + halfWidth;
        }
        // Check Right
        if (pos.x - halfWidth > camBounds.max.x)
        {
            pos.x = camBounds.min.x - halfWidth;
        }
        // Check Top
        if(pos.y - halfHeight > camBounds.max.y)
        {
            pos.y = camBounds.min.y - halfHeight;
        }
        // Check Bottom
        if(pos.y + halfHeight < camBounds.min.y)
        {
            pos.y = camBounds.max.y + halfHeight;
        }
        // Set new position
        transform.position = pos;
    }
}
