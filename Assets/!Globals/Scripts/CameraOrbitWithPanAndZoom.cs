using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbitWithPanAndZoom : MonoBehaviour
{

    public Transform target; // Target object to orbit around
    public float panSpeed = 10f; // Speed of panning
    public float sensitivity = 1f; // Sensitivity of mouse


    // Minimum & maximum zoom distance
    public float distanceMin = .5f;
    public float distanceMax = 15f;

    private float distance = 0f; //Current distance between target amd camera
    // Stored X & Y euler rotation
    private float x = 0.0f;
    private float y = 0.0f;

    // Stored an enum to use for mouse input (just for readability)
    public enum MouseButton
    {
        LEFTMOUSE = 0,
        RIGHTMOUSE = 1,
        MIDDLEMOUSE = 2,
    }
    // Use this for initialization
    void Start()
    {
        target.transform.SetParent(null);

        distance = Vector3.Distance(target.position, transform.position);

        Vector3 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(Input.GetMouseButton((int)MouseButton.RIGHTMOUSE))
        {
            HideCursor(true);
            Orbit();
        }
        else if(Input.GetMouseButton((int)MouseButton.MIDDLEMOUSE))
        {
            HideCursor(true);
            Pan();
        }
        else
        {
            HideCursor(false);
        }
        Movement();
    }

    void Orbit()
    {
        x = x + Input.GetAxis("Mouse Y") * sensitivity;
        y = y - Input.GetAxis("Mouse X") * sensitivity;
    }

    void Movement()
    {
        if (target != null)
        {
            Quaternion rotation = Quaternion.Euler(x, y, 0);

            float desiredDist = distance - Input.GetAxis("Mouse ScrollWheel");
            desiredDist = desiredDist * sensitivity;

            distance = Mathf.Clamp(desiredDist, distanceMin, distanceMax);

            Vector3 invDistanceZ = new Vector3(0, 0, -distance);
            invDistanceZ = rotation * invDistanceZ;

            Vector3 position = target.position + invDistanceZ;

            transform.rotation = rotation;
            transform.position = position;
        }
    }

    void Pan()
    {
        float inputX = -Input.GetAxis("Mouse X");
        float inputY = -Input.GetAxis("Mouse Y");

        Vector3 inputDir = new Vector3(inputX, inputY);

        Vector3 movement = transform.TransformDirection(inputDir);
        target.transform.position += movement * panSpeed * Time.deltaTime;
    }

    void HideCursor(bool isHiding)
    {
        if (isHiding)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

}
