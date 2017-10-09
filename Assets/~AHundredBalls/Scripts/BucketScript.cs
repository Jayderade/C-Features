using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BucketScript : MonoBehaviour
{

    public float movementSpeed = 10.0f;

    private Rigidbody2D rigid2d;    
    private Renderer[] renderers;

    // Use this for initialization
    void Start()
    {
        rigid2d = GetComponent<Rigidbody2D>();        
        renderers = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        HandlePosition();
        HandleBoundary();
    }
    void HandlePosition()
    {
        rigid2d.velocity = Vector3.left * movementSpeed;         
    }

    void HandleBoundary()
    {
        Vector3 transformPos = transform.position;
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transformPos);
        if(IsVisible() == false && viewportPos.x < 0)
        {
            Destroy(gameObject);
        }
    }
    bool IsVisible()
    {
        foreach( var renderer in  renderers)
        {
            if(renderer.isVisible)
            {
                return true;
            }
        }
        return false;
    }
}
